namespace CardDetailsGetter.Model
{
    public class CardDetailString
    {
        public string Scheme { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Prepaid { get; set; }
        public NumberString Number { get; set; }
        public CountryString Country { get; set; }
        public BankString Bank { get; set; }
    }

    public class NumberString
    {
        public string Length { get; set; }
        public string Luhn { get; set; }
    }

    public class CountryString
    {
        public string Numeric { get; set; }
        public string Alpha2 { get; set; }
        public string Name { get; set; }
        public string Emoji { get; set; }
        public string Currency { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class BankString
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}