using Angular2Mvc.DataAccess;
using Angular2Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Angular2Mvc.BusinessService
{
    public class ProductService : BaseService
    {
        #region LoadProducts Method
        public async Task<IList<Product>> Load()
        {
            using(var db = new DbAccessContext())
            {
                var list = await db.Products.ToListAsync();
                return list;
            }
        }
        #endregion

        #region GetProduct Method
        public async Task<Product> Get(int id)
        {
            using (var db = new DbAccessContext())
            {
                return await db.Products.FindAsync(id);
            }
        }
        #endregion

        #region Insert Method
        public bool Insert(Product product)
        {
            IsValid = false;
            using (var db = new DbAccessContext())
            {
                try
                {
                    // Insert the new entity
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    ValidationErrorsToMessages(ex);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
            }
            return IsValid;
        }
        #endregion

        #region Update Method
        public bool Update(Product product)
        {
            IsValid = false;
            using (var db = new DbAccessContext())
            {
                try
                {
                    // Update the product
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    IsValid = true;
                }
                catch (DbEntityValidationException ex)
                {
                    ValidationErrorsToMessages(ex);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
            }

            return IsValid;
        }
        #endregion

        #region Delete Method
        public bool Delete(int id)
        {
            IsValid = false;
            using (var db = new DbAccessContext())
            {
                try
                {
                    // Get the product
                    Product product = db.Products.Find(id);
                    // Delete the product
                    db.Products.Remove(product);
                    db.SaveChanges();

                    IsValid = true;
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
            }

            return IsValid;
        }
        #endregion


    }
}