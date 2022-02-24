using LanguageExt;

namespace CloudHumans.Assignment.Domain.ValueObjects.ProApplication
{
    public class Age : Record<Age>
    {
        private Age(int age) => this.Value = age;

        public int Value { get; }

        public static Age FromInteger(int age)
        {
            if (age >= 18) return new Age(age);

            throw new BusinessException(1, "Pro is ineligible to be paired with any project.");
        }
    }
}