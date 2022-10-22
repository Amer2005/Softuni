function validate(request)
{
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];

    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    let specialCharacters = [`<`, `>`, `\\`, `&`, `'`, `"`];

    if(!validMethods.includes(request.method))
    {
        throw new Error(`Invalid request header: Invalid Method`);
    }

    if(request.uri == undefined)
    {
        throw new Error(`Invalid request header: Invalid URI`);
    }

    if(request.uri != '*')
    {
        if(request.uri == '')
        {
            throw new Error(`Invalid request header: Invalid URI`);
        }

        for(let i = 0;i < request.uri.length;i++)
        {
            if(request.uri[i] == '.')
            {
                continue;
            }

            if(request.uri[i] >= 'a' && request.uri[i] <= 'z')
            {
                continue;
            }

            if(request.uri[i] >= 'A' && request.uri[i] <= 'Z')
            {
                continue;
            }

            if(request.uri[i] >= '0' && request.uri[i] <= '9')
            {
                continue;
            }

            throw new Error(`Invalid request header: Invalid URI`);
        }
    }

    if(!validVersions.includes(request.version))
    {
        throw new Error(`Invalid request header: Invalid Version`);
    }

    if(request.message == undefined)
    {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    for(let i = 0;i < request.message.length;i++)
    {
        if(specialCharacters.includes(request.message[i]))
        {
            throw new Error(`Invalid request header: Invalid Message`);
        }
    }

    return request;
}

validate({
    method: 'GET',
    uri: 'svn.-public.catalog',
    version: 'HTTP/1.1',
    message: '<script>alert("xss vulnerable")</script>'
  }
);