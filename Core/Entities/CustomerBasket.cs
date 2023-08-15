using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
                
        }
        public CustomerBasket(string id)
        {
            Id = id;
            items =  new List<BasketItem>();


        }
        [DataMember]
        public string Id { get; set; } // because the basket is really customer thing
        public List<BasketItem> items { get; set; }           // and is not something we are storing in our database 
                                       //then we will let the customer(angular) generate the id (unique) of the basket 



    }
}
