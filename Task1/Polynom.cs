using System;
using System.Collections;
using System.Linq;
using System.Configuration;

namespace Task1
{
    public class Polynom: ICloneable
    {
        #region private fields
        internal double[] _coefficients;
        private static double epsilon;
        #endregion

        #region public properties
        public double this[int index] => _coefficients[index];
        public int Power
        {
            get
            {
                for (int i=_coefficients.Length; i>=0; i--)
                    if (_coefficients[i] > epsilon) return i;
                return 0;
            }
        }
        #endregion

        #region public methods
        #region constructors 
        static Polynom()
        {
            try
            {
                epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"]);
            }
            catch
            {
                epsilon = 0.0000001;
            }
        }   
           
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynom"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        public Polynom(params double[] coefficients)
        {
            if (ReferenceEquals(coefficients, null)) throw new ArgumentNullException();
            _coefficients = ((double[])coefficients.Clone());
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
            int maxLength = Math.Max(left._coefficients.Length, right._coefficients.Length);
            int minLength = Math.Min(left._coefficients.Length, right._coefficients.Length);
            double[] extra = left._coefficients.Length > right._coefficients.Length ? left._coefficients : right._coefficients;
            double[] coefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++) coefficients[i] = left._coefficients[i] + right._coefficients[i];
            for (int i = minLength; i < maxLength; i++) coefficients[i] = extra[i];
            return new Polynom(coefficients);
        }

        /// <summary>
        /// Implements the operator - for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="lhs">Left polynom.</param>
        /// <param name="rhs">Right polynom.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator -(Polynom lhs, Polynom rhs) => Add(lhs, Negate(rhs));

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="obj">The instance of <see cref="Polynom" />.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator -(Polynom obj) => Negate(obj);

        /// <summary>
        /// Substracts from the specified left <see cref="Polynom" /> right <see cref="Polynom" />.
        /// </summary>
        /// <param name="lhs">Left polynom.</param>
        /// <param name="rhs">Right polynom.</param>
        /// <returns>New <see cref="Polynom" />.</returns>
        public static Polynom Substract(Polynom lhs, Polynom rhs) => Add(lhs, Negate(rhs));

        /// <summary>
        /// Negates the specified instance of <see cref="Polynom" />.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>New instance of <see cref="Polynom" /></returns>
        public static Polynom Negate(Polynom obj) => new Polynom(obj._coefficients.Select(x => -x).ToArray());

        /// <summary>
        /// Implements the operator * for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="lhs">Left polynom.</param>
        /// <param name="rhs">Right polynom.</param>
        /// <returns>
        /// New <see cref="Polynom" />.
        /// </returns>
        public static Polynom operator *(Polynom lhs, Polynom rhs) => Multiply(lhs, rhs);

        /// <summary>
        /// Multiplies the specified left <see cref="Polynom" /> with right <see cref="Polynom" />.
        /// </summary>
        /// <param name="lhs">Left polynom.</param>
        /// <param name="rhs">Right polynom.</param>
        /// <returns>New <see cref="Polynom" />.</returns>
        private static Polynom Multiply(Polynom lhs, Polynom rhs)
        {
            int maxLength = Math.Max(lhs._coefficients.Length, rhs._coefficients.Length);
            int minLength = Math.Min(lhs._coefficients.Length, rhs._coefficients.Length);
            double[] extra = lhs._coefficients.Length > rhs._coefficients.Length ? lhs._coefficients : rhs._coefficients;
            double[] coefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++) coefficients[i] = lhs._coefficients[i] * rhs._coefficients[i];
            for (int i = minLength; i < maxLength; i++) coefficients[i] = extra[i];
            return new Polynom(coefficients);
        }

        /// <summary>
        /// Implements the operator == for two instances of <see cref="Polynom" />.
        /// </summary>
        /// <param name="lhs">Left polynom.</param>
        /// <param name="rhs">Right polynom.</param>
        /// <returns>
        /// <c>true</c> if polynoms are equal, otherwise <c>false</c>
        /// </returns>
        public static bool operator ==(Polynom lhs, Polynom rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (!ReferenceEquals(lhs, null)) return lhs.Equals(rhs);
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
            if (obj._coefficients.Length != obj._coefficients.Length) return false;

            IStructuralEquatable coefficients = _coefficients;
            return coefficients.Equals(obj._coefficients, StructuralComparisons.StructuralEqualityComparer);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => _coefficients.GetHashCode() ^ _coefficients.Length;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            const int visiblePower = 1;

            int power = _coefficients.Length - 1;
            bool firstsign = true;
            string result = string.Empty;
            for (int i = 0; i < _coefficients.Length; i++)
            {
                if (Math.Abs(_coefficients[i]) > epsilon)
                {
                    string sign = (firstsign || _coefficients[i] < 0) ? string.Empty : "+";
                    string coefficient = _coefficients[i].ToString("F");
                    string variable = (i != _coefficients.Length - 1) ? "*x" : string.Empty;
                    string n = (power - i > visiblePower) ? "^" + (power - i) : string.Empty;
                    result += $"{sign}{coefficient}{variable}{n}";
                    firstsign = false;
                }
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
        /// Creates a new <see cref="System.Object" /> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="System.Object" /> that is a copy of the current instance.
        /// </returns>
        object ICloneable.Clone() => Clone();

        /// <summary>
        /// Creates a new instance of <see cref="Polynom" /> that is a copy of the current instance.
        /// </summary>
        /// <returns>a new instance of <see cref="Polynom" /> that is a copy of the current instance.</returns>
        public Polynom Clone() => new Polynom(_coefficients);
        #endregion
        #endregion
    }
}
