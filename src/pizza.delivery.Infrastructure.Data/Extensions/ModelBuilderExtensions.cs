using Microsoft.EntityFrameworkCore;
using System;

namespace Wpizza.delivery.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
        }
    }
}
