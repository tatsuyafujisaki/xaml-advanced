using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public sealed class RestaurantContext
    {
        public List<Table> Tables { get; private set; }

        public List<MenuItem> StandardMenuItems { get; private set; }

        public List<Order> Orders { get; private set; }

        public async Task InitializeContextAsync()
        {
            //DO NOT REMOVE: Simulates network congestion
            await Task.Delay(TimeSpan.FromSeconds(2.5d));

            this.Tables = new List<Table>
            {
                new Table { Description = "Back-Corner Two Top" },
                new Table { Description = "Front Booth" }
            };

            this.StandardMenuItems = new List<MenuItem>
            {
                new MenuItem { Title = "French Bread & Fondue Dip", Price = 5.75m },
                new MenuItem { Title = "Curried Chicken and Rice", Price = 9.00m },
                new MenuItem { Title = "Feta-Stuffed Chicken", Price = 8.25m },
                new MenuItem { Title = "Grilled Pork Loin", Price = 11.50m },
                new MenuItem { Title = "Carnitas Tacos", Price = 7.50m },
                new MenuItem { Title = "Filet Mignon & Asparagus", Price = 15.75m },
                new MenuItem { Title = "T-Bone Steak", Price = 12.25m },
                new MenuItem { Title = "Pineapple and Pear Salad", Price = 6.25m },
                new MenuItem { Title = "Sauteed Broccolini", Price = 3.75m },
                new MenuItem { Title = "Mashed Peas", Price = 3.25m }
            };

            this.Orders = new List<Order>
            {
                new Order { Complete = false, Expedite = true, SpecialRequests = "Allergic to Shellfish", Table = this.Tables.Last(), Items = new List<MenuItem> { this.StandardMenuItems.First() } },
                new Order { Complete = false, Expedite = false, SpecialRequests = String.Empty, Table = this.Tables.Last(), Items = new List<MenuItem> { this.StandardMenuItems.Last(), this.StandardMenuItems.First() } },
            };
        }
    }
}
