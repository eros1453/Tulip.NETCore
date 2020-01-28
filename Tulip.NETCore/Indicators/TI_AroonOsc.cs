namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AroonOscStart(double[] options)
        {
            return (int) options[0];
        }
        private static int AroonOscStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int AroonOsc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] output = outputs[0];
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AroonStart(options))
            {
                return TI_OKAY;
            }

            double scale = 100.0 / period;
            int maxi = -1;
            int mini = -1;
            double max = high[0];
            double min = low[0];

            int outputIndex = default;
            for (int i = period, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                double bar = high[i];
                int j;
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    j = trail;
                    while (++j <= i)
                    {
                        bar = high[j];
                        if (bar >= max)
                        {
                            max = bar;
                            maxi = j;
                        }
                    }
                }
                else if (bar >= max)
                {
                    maxi = i;
                    max = bar;
                }


                // Maintain lowest.
                bar = low[i];
                if (mini < trail)
                {
                    mini = trail;
                    min = low[mini];
                    j = trail;
                    while (++j <= i)
                    {
                        bar = low[j];
                        if (bar <= min)
                        {
                            min = bar;
                            mini = j;
                        }
                    }
                }
                else if (bar <= min)
                {
                    mini = i;
                    min = bar;
                }

                output[outputIndex++] = (maxi - mini) * scale;
            }

            return TI_OKAY;
        }

        private static int AroonOsc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] output = outputs[0];
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AroonStart(options))
            {
                return TI_OKAY;
            }

            decimal scale = 100m / period;
            int maxi = -1;
            int mini = -1;
            decimal max = high[0];
            decimal min = low[0];

            int outputIndex = default;
            for (int i = period, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                decimal bar = high[i];
                int j;
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    j = trail;
                    while (++j <= i)
                    {
                        bar = high[j];
                        if (bar >= max)
                        {
                            max = bar;
                            maxi = j;
                        }
                    }
                }
                else if (bar >= max)
                {
                    maxi = i;
                    max = bar;
                }


                // Maintain lowest.
                bar = low[i];
                if (mini < trail)
                {
                    mini = trail;
                    min = low[mini];
                    j = trail;
                    while (++j <= i)
                    {
                        bar = low[j];
                        if (bar <= min)
                        {
                            min = bar;
                            mini = j;
                        }
                    }
                }
                else if (bar <= min)
                {
                    mini = i;
                    min = bar;
                }

                output[outputIndex++] = (maxi - mini) * scale;
            }

            return TI_OKAY;
        }
    }
}
