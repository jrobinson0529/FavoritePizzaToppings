using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoritePizzaToppings.Pizzas
{
    class Pizza
    {
        [JsonProperty("toppings")]
        public List<string> Toppings { get; set; }
    }
}
