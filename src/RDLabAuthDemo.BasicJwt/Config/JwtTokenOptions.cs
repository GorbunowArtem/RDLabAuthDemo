namespace RDLabAuthDemo.BasicJwt.Config
{
	public class JwtTokenOptions
	{
		public const string Name = "JwtToken";
		
		public string Issuer { get; set; }

		public string Key { get; set; }

		public string Audience { get; set; }
	}
}