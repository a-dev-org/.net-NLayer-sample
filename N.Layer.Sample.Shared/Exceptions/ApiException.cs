using System;

namespace N.Layer.Sample.Shared.Exceptions;

public class ApiException(string message) : Exception(message);