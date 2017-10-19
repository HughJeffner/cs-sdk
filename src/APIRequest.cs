using System;
using System.Collections.Generic;
using System.Text;

class APIRequest
{

    #region Fields
    string _key;
    string _token;
    string _output;
    List<RequestFields> _requestFields;
    #endregion

    public APIRequest()
    {
        _requestFields = new List<RequestFields>();
    }

    #region Property

    public List<RequestFields> RequestFields
    {
        get { return _requestFields; }
        set { _requestFields = value; }
    }
    
    public string Key
    {
        get { return _key; }
        set { _key = value; }
    }

    public string Token
    {
        get { return _token; }
        set { _token = value; }
    }

    public string Output
    {
        get { return _output; }
        set { _output = value; }
    }

    #endregion

    #region Methods

    public string GetEncoded()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"{""key"": """ + _key +
                        @""", ""token"": """ + _token +
                        @""", ""output"": """ + _output +
                        @""", ""request"": [");

        foreach (RequestFields requestFields in _requestFields)
        {
            if (_requestFields.Count > 0)
            {
                builder.Append("{");
                foreach (KeyValuePair<string, object> item in requestFields)
                {
                    if (item.Value.GetType().ToString() == "System.String")
                        builder.Append(@"""" + item.Key + @""": """ + item.Value + @""",");
                    else
                        builder.Append(@"""" + item.Key + @""": " + item.Value + ",");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("},");
            }
        }
        builder.Remove(builder.Length - 1, 1);
        builder.Append("]}");
        return builder.ToString();
    }

    #endregion
}
