using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persistence_Layer.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace Web_API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IConfiguration _config;
        protected readonly IMapper _mapper;
        public BaseApiController(IUnitOfWork unitOfWork, IConfiguration config, IMapper mapper)
        {
            this._config = config;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        protected IActionResult GetModalStateMessage()
        {
            var error = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            var stringBuilder = new StringBuilder();

            foreach (var e in error)
            {
                stringBuilder.Append(e + ",");
            };

            stringBuilder.Append("Invalid Request");

            return BadRequest(stringBuilder.ToString());
        }


        protected IActionResult HandleException(Exception exception)
        {
            // if (exception.GetType().Name == "DbUpdateException")
            // {
            //     return BadRequest(exception.InnerException.InnerException);
            // }
            // else if (exception.GetType().Name == "DbEntityValidationException")
            // {
            //     var stringBuilder = new StringBuilder();

            //     var dbEntityValidationException = (DbEntityValidationException)exception;

            //     foreach (var entityValidationErrors in dbEntityValidationException.EntityValidationErrors)
            //     {
            //         foreach (var validationError in entityValidationErrors.ValidationErrors)
            //         {
            //             stringBuilder.Append("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + ",");
            //         }
            //     }

            //     stringBuilder.Append("Invalid Request");

            //     return BadRequest(stringBuilder.ToString());
            // }
            // return InternalServerError(exception);
            return BadRequest(exception.Message);
        }

        protected static T GetSortBy<T>(string sortBy, T defaultSortBy)
        {
            T _SortBy = defaultSortBy;

            if (!string.IsNullOrEmpty(sortBy))
            {
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    if (((T)item).ToString().ToUpper() == sortBy.ToUpper())
                    {
                        _SortBy = ((T)item);
                    }
                }
            }

            return _SortBy;
        }
    }
}