﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ru.org.openam.sdk.auth;
using ru.org.openam.sdk.auth.callback;

namespace ru.org.openam.sdk
{
    class Auth
    {
        public static Session login(String realm, indexType indexType, String IndexName,Callback[] callbacks)
        {
            Request request = new Request(Auth.Get(new auth.Request(realm, indexType, IndexName)));
            request.callbacks.Clear();
            request.callbacks.AddRange(callbacks);

            Response response=Auth.Get(request);
            if (response.exception != null)
                throw response.exception;
            return new Session(response.ssoToken);
        }

        public static auth.Response Get(auth.Request request)
        {
            pll.ResponseSet responses=RPC.Get(new pll.RequestSet(new auth.Request[]{request}));
            if (responses.Count > 0)
                return (auth.Response)responses[0];
            return new auth.Response();
        }
    }
}