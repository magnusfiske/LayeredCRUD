using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{


    internal class Controller
    {

        IDAO database;
        IStringIO io;
        public Controller(IDAO database, IStringIO io)
        {
            this.database = database;
            this.io = io;
        }

        public void Start()
        {
            bool isOn = true;

            while(isOn)
            {
                io.Output("Välj vad du vill göra genom att ange en bokstav:\nc - create\nr - read\nu - update\nd - delete");
                string input = io.Input();
                switch (input)
                {
                    case "c":
                        AddProduct();
                        break;
                    case "r":
                        GetProducts();
                        break;
                    case "u":
                        UpdateProduct();
                        break;
                    case "d":
                        DeleteProduct();
                        break;
                    default:
                        io.Output("Dålig input, försök igen");
                        break;
                }
            }
        }

        public void AddProduct()
        {

        }

        public void GetProducts()
        {
            var products = database.Read();

            foreach (var product in products)
            {
                io.Output(product.ToString());
            }
        }

        public void UpdateProduct()
        {
            io.Output("Ange id för produkten du vill uppdatera");
            string id = io.Input();
            io.Output("Ange nytt pris för produkten");
            string newPrice = io.Input();
            database.UpdatePrice(id, newPrice);

        }

        public void DeleteProduct()
        {

        }
    }
}
