
namespace BattleShipsOOP
{
    public class Coords
    {
        private int _x;
        private int _y;

        public Coords(int x ,int y )
        {
            _x=x;
            _y=y;
        }

       
        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }



    }
}
