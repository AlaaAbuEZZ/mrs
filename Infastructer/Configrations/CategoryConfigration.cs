using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructer.Configrations
{
    public class CategoryConfigration:IEntityTypeConfiguration<Category>
    {
        public void configure(EntityTypeBuilder<Category> builder)
        {


            builder.HasData(

                new Category
                {
                    Id = Guid.Parse("2e46372e-7589-4843-992b-20c5a738e389"),
                    Name = ("IT"),
                    Description = ("email")
                },
                new Category
                {
                    Id = Guid.Parse("2e46372e-7589-4843-992b-20c5a738e390"),
                    Name= ("Electric"),
                    Description = ("short")
                }


                );
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            throw new NotImplementedException();
        }
    }
}
