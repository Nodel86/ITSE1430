using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nile.Data
{
    /// <summary>Provides a base implementation of <see cref="IProductDatabase"/>.</summary>
    public abstract class ProductDatabase : IProductDatabase

    {

        /// <summary>Add a new product.</summary>

        /// <param name="product">The product to add.</param>

        /// <param name="message">Error message.</param>

        /// <returns>The added product.</returns>

        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>

        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>

        /// <exception cref="Exception">A product with the same name already exists.</exception>

        /// <remarks>

        /// Returns an error if product is null, invalid or if a product

        /// with the same name already exists.

        /// </remarks>
        public Product Add( Product product, out string message )
        {
            //Check for null
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            var errors = product.Validate();
            //var errors = ObjectValidator.Validate(product);
            //if (errors.Count() > 0)
            //{
            //    var error = Enumerable.First(errors);

            //    //Get first error                
            //    message = errors.ElementAt(0).ErrorMessage;
            //    return null;
            //};
            var error = errors.FirstOrDefault();
            if (error != null)
            {
                message = error.ErrorMessage;
                return null;
            };

            // Verify unique product

            var existing = GetProductByNameCore(product.Name);

            if (existing != null)
            {
                message = "Product already exists.";
                return null;
            };

            message = null;
            return AddCore(product);

        }



        /// <summary>Gets all products.</summary>

        /// <returns>The list of products.</returns>

        public IEnumerable<Product> GetAll()

        {

            return GetAllCore();

        }



        /// <summary>Removes a product.</summary>

        /// <param name="id">The product ID.</param>

        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>

        public void Remove( int id )
        {
            //TODO: Return an error if id <= 0

            if (id > 0)
            {
                RemoveCore(id);
            };
        }



        /// <summary>Edits an existing product.</summary>

        /// <param name="product">The product to update.</param>

        /// <returns>The updated product.</returns>

        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>

        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>

        /// <exception cref="Exception">A product with the same name already exists.</exception>

        /// <exception cref="ArgumentException">The product does not exist.</exception>

        /// <remarks>

        /// Returns an error if product is null, invalid, product name

        /// already exists or if the product cannot be found.

        /// </remarks>
        public Product Update( Product product, out string message )
        {
            message = "";

            //Check for null

            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product using IValidatableObject
            //var error = product.Validate();
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                //Get first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            // Verify unique product

            var existing = GetProductByNameCore(product.Name);

            if (existing != null && existing.Id != product.Id)
            {
                message = "Product already exists.";
                return null;
            };

            //Find existing

            existing = existing ?? GetCore(product.Id);

            if (existing == null)
            {
                message = "Product not found.";
                return null;
            };

            return UpdateCore(product);

        }



        protected abstract Product AddCore( Product product );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract Product GetCore( int id );

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product product );

        protected abstract Product GetProductByNameCore( string name );

    }

}