using System.Linq;
using FluentValidation;
using RestaurantWebApi.Entities;
using RestaurantWebApi.Models;

namespace RestaurantWebApi.Validators
{
    public class RestaurantQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new int[] { 5, 10, 15 };

        private string[] allowedSortByColumnNames = new[] {nameof(Restaurant.Name),nameof(Restaurant.Description), nameof(Restaurant.Category)};
        public RestaurantQueryValidator()
        {
            RuleFor(r => r.pageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.pageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize",$"Page size must be in [{string.Join(',',allowedPageSizes)}]");
                }
            });

            RuleFor(r => r.SortBy).Custom((value, context) =>
            {
                // if sortby is not in array && if sortby is not empty
                if (!allowedSortByColumnNames.Contains(value) && !string.IsNullOrEmpty(value))
                {
                    context.AddFailure("SortBy",$"You can only sort by: [{string.Join(",",allowedSortByColumnNames)}]");
                }
            });

            // THE SAME AS UPPER ONE
            //RuleFor(r => r.SortBy)
            //    .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
            //    .WithMessage($"sort by is optional or must be in [{string.Join(",", allowedSortByColumnNames)}]");

        }
    }
}
