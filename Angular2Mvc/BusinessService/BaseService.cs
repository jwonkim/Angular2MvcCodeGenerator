using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Angular2Mvc.BusinessService
{
    public class BaseService
    {
        public List<KeyValuePair<string, string>> Messages { get; set; }
        public Exception LastException { get; set; }
        public bool IsValid { get; set; }


        #region ValidationErrorsToMessages Method
        protected void ValidationErrorsToMessages(DbEntityValidationException ex)
        {
            foreach (DbEntityValidationResult result in ex.EntityValidationErrors)
            {
                foreach (DbValidationError item in result.ValidationErrors)
                {
                    Messages.Add(new KeyValuePair<string, string>(item.PropertyName, item.ErrorMessage));
                }
            }
        }
        #endregion

    }
}