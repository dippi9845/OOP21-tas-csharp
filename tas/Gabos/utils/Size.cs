namespace tas.Gabos.utils
{

    /// <summary>
    ///     Class that handles a size.
    /// </summary>
    public class Size
    {

        /// <summary>
        ///     The width of the size.
        /// </summary>
        public double Width { get; }

        /// <summary>
        ///     The Height of the size.
        /// </summary>
        public double Height { get; }

        /// <summary>
        ///     Constructor that creates the size.
        /// </summary>
        /// <param name="width"> The width of the size.</param>
        /// <param name="height"> The Height of the size.</param>
        public Size(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Constructor that creates the size.
        /// </summary>
        /// <param name="width"> The width of the size.</param>
        /// <param name="height"> The Height of the size.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

    }
}
