
namespace ClassLibrary
{
    public class Item
    {
        private int id;

        private string name;

        private string color;

        private double price;

        private string provider;

        private DateOnly productionDate;

        public int Id
        {
            get
            {
                return id;
            }
            private set { }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set { }
        }
        public string Color
        {
            get
            {
                return color;
            }
            private set { }
        }
        public double Price
        {
            get
            {
                return price;
            }
            private set { }
        }
        public string Provider { 
            get    
            {
                return provider;
              }
            private set { } 
        }

        public DateOnly ProductionDate
        {
            get
            {
                return productionDate;
            }
            private set { }
        }

    

        public Item(int id, string name, string color, double price, string provider, DateOnly productionDate)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.price = price;
            this.provider = provider;
            this.productionDate = productionDate;
        }
        public override string ToString()
        {
            return $"\tАртикул {id}. Наименование {name}. Цвет {color}. Стоимость {price}. Поставщик {provider}. Дата производства {productionDate}\n";
        }
    }
}
