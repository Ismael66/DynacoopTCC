using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Models
{
    public class Oportunidade
    {
        public EntityReference ValidateLookup(KeyValuePair<string, object> value, IOrganizationService service, IOrganizationService service2)
        {
            var entityReference = (EntityReference)value.Value;

            var createdEntityId = CreateAndGetEntity(entityReference, service, service2);
            return new EntityReference(entityReference.LogicalName, createdEntityId);
        }

        public Guid CreateAndGetEntity(EntityReference entityReference, IOrganizationService service, IOrganizationService service2)
        {
            var entity = service.Retrieve(entityReference.LogicalName, entityReference.Id, new ColumnSet(getEntityColumns(entityReference.LogicalName)));

            var entityExists = ValidadteDuplicate(entity, service2);

            if (entityExists == Guid.Empty)
            {
                var IntegrationEntity = new Entity(entityReference.LogicalName);

                foreach (var field in entity.Attributes)
                {
                    if (field.Value != null)
                    {
                        if (field.Value.GetType() == new EntityReference().GetType())
                        {
                            if (!getIgnoreFields().ToList().Contains(((EntityReference)field.Value).LogicalName) && field.Key != $"{((EntityReference)field.Value).LogicalName}id")
                                IntegrationEntity[field.Key] = ValidateLookup(field, service, service2);
                        }
                        else
                        {
                            IntegrationEntity[field.Key] = field.Value;
                        }
                    }
                }

                var guid = service2.Create(IntegrationEntity);

                return guid;
            }
            
            return entityExists;
            
        }

        public Guid ValidadteDuplicate(Entity entity, IOrganizationService service)
        {
            var query = new QueryExpression(entity.LogicalName);
            query.Criteria.AddCondition(getNameField(entity.LogicalName), ConditionOperator.Equal, entity[getNameField(entity.LogicalName)]);

            var result = service.RetrieveMultiple(query).Entities;

            if (result.Count > 0)
                return result[0].Id;

            return default(Guid);
        }

        public string getNameField(string logicalName)
        {
            switch (logicalName)
            {
                case "account":
                case "pricelevel":
                case "uom":
                case "uomschedule":
                    return "name";

                case "contact":
                    return "fullname";

                case "transactioncurrency":
                    return "currencycode";

                default:
                    return "name";
            }
        }

        public string[] getEntityColumns(string entityName)
        {
            switch (entityName)
            {
                case "account":
                    return new string[] { "name", "telephone1", "fax", "websiteurl", "parentaccountid", "tickersymbol", "address1_line1", "defaultpricelevelid" };

                case "pricelevel":
                    return new string[] { "name", "begindate", "enddate", "transactioncurrencyid" };

                case "uom":
                    return new string[] { "name", "uomscheduleid", "quantity", "baseuom" };

                case "uomschedule":
                    return new string[] { "name", "description" };

                case "contact":
                    return new string[] { "fullname", "firstname", "lastname", "jobtitle", "parentcustomerid", "emailaddress1", "telephone1", "mobilephone",
                                          "fax", "preferredcontactmethodcode", "address1_stateorprovince", "address1_city", "address1_country", 
                                          "address1_postalcode", "address1_line1" };

                case "transactioncurrency":
                    return new string[] { "currencyname", "currencycode", "currencyprecision", "currencysymbol", "exchangerate" };

                case "opportunity":
                    return new string[] { "name", "parentcontactid", "parentaccountid", "purchasetimeframe", "transactioncurrencyid", "budgetamount",
                                          "purchaseprocess", "description", "msdyn_forecastcategory", "currentsituation", "customerneed", "proposedsolution" };

                default:
                    return new string[] { "name" };
            }
        }

        public string[] getIgnoreFields()
        {
            return new string[] { "systemuser", "organization", "team", "businessunit", "msdyn_predictivescore", "createdon", "createdby", "modifiedon", "modifiedby", "ownerid" };
        }
    }
}
