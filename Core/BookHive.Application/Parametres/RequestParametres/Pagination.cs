

namespace BookHive.Application.Parametres.RequestParametres
{
    public record Pagination
    {
        private int _page = 0;
        private int _size = 5;
        public int Page
        {
            get => _page;
            set
            {
                if (value < 0)
                {
                    _page = 0; 
                }
                else
                {
                    _page = value; 
                }
            }
        }

        public int Size
        {
            get=> _size;
            set
            {
                if (value <= 5)
                {
                    _size = 5;
                }
                else
                {
                    _size = value;
                }
            }
        }

    }
}
