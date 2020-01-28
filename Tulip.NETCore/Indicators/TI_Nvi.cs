namespace Tulip
{
    internal static partial class Tinet
    {
        private static int NviStart(double[] options)
        {
            return 0;
        }

        private static int NviStart(decimal[] options)
        {
            return 0;
        }

        private static int Nvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] close = inputs[0];
            double[] volume = inputs[1];
            double[] output = outputs[0];

            if (size <= NviStart(options))
            {
                return TI_OKAY;
            }

            var nvi = 1000.0;
            int outputIndex = default;
            output[outputIndex++] = nvi;
            for (var i = 1; i < size; ++i)
            {
                if (volume[i] < volume[i - 1])
                {
                    nvi += (close[i] - close[i - 1]) / close[i - 1] * nvi;
                }

                output[outputIndex++] = nvi;
            }

            return TI_OKAY;
        }

        private static int Nvi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] close = inputs[0];
            decimal[] volume = inputs[1];
            decimal[] output = outputs[0];

            if (size <= NviStart(options))
            {
                return TI_OKAY;
            }

            var nvi = 1000m;
            int outputIndex = default;
            output[outputIndex++] = nvi;
            for (var i = 1; i < size; ++i)
            {
                if (volume[i] < volume[i - 1])
                {
                    nvi += (close[i] - close[i - 1]) / close[i - 1] * nvi;
                }

                output[outputIndex++] = nvi;
            }

            return TI_OKAY;
        }
    }
}
