public struct GridPosition {

    public int x, y, z;

    public GridPosition(int x, int y, int z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString() {
        return $"x: {x}, y: {y}, z: {z}";
    }

    public static GridPosition operator +(GridPosition a, GridPosition b) {
        return new GridPosition(a.x + b.x, a.y + b.y, a.z + b.z);
    }

}
