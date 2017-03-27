using System;
using System.Collections;

namespace Task1
{
    public class Polynom
    {
        #region private fields
        private double[] _coefficients;

        private int power;
        #endregion

        #region public properties        
        /// <summary>
        /// Gets the coefficients.
        /// </summary>
        /// <value>
        /// The coefficients.
        /// </value>
        public double[] Coefficients => (double[])_coefficients.Clone();

        /// <summary>
        /// Gets the power of polynom.
        /// </summary>
        /// <value>
        /// The power of polynom.
        /// </value>
        public int Power => (power);
        #endregion

        #region public methods
        #region constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="first">The first coefficient.</param>
        public Polynom(double first)
        {
            _coefficients = new double[] { first };
            power = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="first">The first coefficient.</param>
        /// <param name="second">The second coefficient.</param>
        public Polynom(double first, double second)
        {
            _coefficients = new double[] { first, second };
            power = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="first">The first coefficient.</param>
        /// <param name="second">The second coefficient.</param>
        /// <param name="third">The third coefficient.</param>
        public Polynom(double first, double second, double third)
        {
            _coefficients = new double[] { first, second, third };
            power = 2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        public Polynom(params double[] coefficients)
        {
            if (ReferenceEquals(coefficients, null)) throw new ArgumentNullException();

            if (coefficients.Length == 0)
            {
                _coefficients = new double[0];
                power = 0;
            }
            else
            {
                _coefficients = ((double[])coefficients.Clone());
                power = Coefficients.Length-1;
            }

        }
        #endregion

        #region overriden methods
        /// <summary>
        /// Implements the operator + for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator +(Polynom left, Polynom right) => Add(left, right);

        /// <summary>
        /// Adds the specified left <see cref="Polynom" /> to the right <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>New <see cref="Polynom" />.</returns>
        public static Polynom Add(Polynom left, Polynom right)
        {
            int maxLength = Math.Max(left.Coefficients.Length, right.Coefficients.Length);
            int minLength = Math.Min(left.Coefficients.Length, right.Coefficients.Length);
            double[] extra = left.Coefficients.Length > right.Coefficients.Length ? left.Coefficients : right.Coefficients;
            double[] coefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++) coefficients[i] = left.Coefficients[i] + right.Coefficients[i];
            for (int i = minLength; i < maxLength; i++) coefficients[i] = extra[i];
            return new Polynom(coefficients);
        }

        /// <summary>
        /// Implements the operator - for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator -(Polynom left, Polynom right) => Substract(left, right);

        /// <summary>
        /// Substracts from the specified left <see cref="Polynom" /> right <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>New <see cref="Polynom" />.</returns>
        private static Polynom Substract(Polynom left, Polynom right)
        {
            int maxLength = Math.Max(left.Coefficients.Length, right.Coefficients.Length);
            int minLength = Math.Min(left.Coefficients.Length, right.Coefficients.Length);
            bool reverse = (maxLength == right.Coefficients.Length);
            double[] extra = left.Coefficients.Length > right.Coefficients.Length ? left.Coefficients : right.Coefficients;
            double[] coefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++) coefficients[i] = left.Coefficients[i] - right.Coefficients[i];
            for (int i = minLength; i < maxLength; i++) coefficients[i] = reverse?0 - extra[i]:extra[i];
            return new Polynom(coefficients);
        }

        /// <summary>
        /// Implements the operator * for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator *(Polynom left, Polynom right) => Multiply(left, right);

        /// <summary>
        /// Multiplies the specified left <see cref="Polynom" /> with right <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>New <see cref="Polynom" />.</returns>
        private static Polynom Multiply(Polynom left, Polynom right)
        {
            int maxLength = Math.Max(left.Coefficients.Length, right.Coefficients.Length);
            int minLength = Math.Min(left.Coefficients.Length, right.Coefficients.Length);
            double[] extra = left.Coefficients.Length > right.Coefficients.Length ? left.Coefficients : right.Coefficients;
            double[] coefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++) coefficients[i] = left.Coefficients[i] * right.Coefficients[i];
            for (int i = minLength; i < maxLength; i++) coefficients[i] = extra[i];
            return new Polynom(coefficients);
        }

        /// <summary>
        /// Implements the operator == for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>
        /// <c>true</c> if polynoms are equal, otherwise <c>false</c>
        /// </returns>
        public static bool operator ==(Polynom left, Polynom right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (!ReferenceEquals(left, null)) return left.Equals(right);
            return false;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is Polynom) return Equals((Polynom)obj);
            return false;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Polynom" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Polynom" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="Polynom" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Polynom obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (Power != obj.Power) return false;

            IStructuralEquatable coefficients = Coefficients;
            return coefficients.Equals(obj.Coefficients, StructuralComparisons.StructuralEqualityComparer);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => Coefficients.GetHashCode() ^ Power;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            const int visiblePower = 1;
            string result = string.Empty;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                string sign = (i == 0 || Coefficients[i] < 0) ? string.Empty : "+";
                string coefficient = Coefficients[i].ToString("F");
                string variable = (i != Coefficients.Length - 1) ? "*x" : string.Empty;
                string n = (power-i > visiblePower) ? "^" + (power-i) : string.Empty;
                result += $"{sign}{coefficient}{variable}{n}";
            }

            return result;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">Left polynom.</param>
        /// <param name="right">Right polynom.</param>
        /// <returns>
        /// <c>true</c> if polynoms aren't equal, otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(Polynom left, Polynom right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (!ReferenceEquals(left, null)) return !left.Equals(right);
            return true;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()=>new Polynom(Coefficients);
        #endregion
        #endregion
    }
}
