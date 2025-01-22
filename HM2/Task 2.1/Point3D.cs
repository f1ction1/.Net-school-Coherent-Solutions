namespace Task2
{
    internal class Point3D
    {
        float[] _coordinates;
        double _mass;

        public float X
        {
            get { return _coordinates[0]; }
            set { _coordinates[0] = value; }
        }
        public float Y
        {
            get { return _coordinates[1]; }
            set { _coordinates[1] = value; }
        }
        public float Z
        {
            get { return _coordinates[2]; }
            set { _coordinates[2] = value; }
        }

        public double Mass
        {
            get { return _mass; }
            set 
            {
                if(value >= 0) 
                    _mass = value;
                else _mass = 0;
            }
        }
        public Point3D()
        {
            _coordinates = new float[3] { 0, 0, 0 };
            _mass = 0;
        }
        public Point3D(float[] coordinates, double mass)
        {
            _coordinates = new float[coordinates.Length];
            for(int i = 0; i < coordinates.Length; i++) 
            {
                _coordinates[i] = coordinates[i];
            }
            _mass = mass;
        }
        public bool IsZero()
        {
            return _coordinates[0] == 0 && _coordinates[1] == 0 && _coordinates[2] == 0 ? true : false;
        }
        public float DistanceBetween(Point3D p)
        {
            return p!=null ? (float)Math.Sqrt(Math.Pow((p.X - _coordinates[0]), 2) + Math.Pow((p.Y - _coordinates[1]), 2) + Math.Pow((p.Z - _coordinates[2]), 2))
                    : throw new Exception("Point can't be null");
        }
        public override string ToString()
        {
            return $"Point: [{this.X}, {this.Y}, {this.Z}] with mass: {this.Mass} kg";
        }
    }
}
