using System;
using System.Net.Sockets;

public class Option
{
	public string OptionName {  get; set; }
	public string OptionKey { get; set; }


	public Option(string optionName, string optionKey)
	{
		OptionName = optionName;
		OptionKey = optionKey;
	}
}
