using FluentValidation;

namespace GeoServerNet.Application.Exeptions;

public class CqrsDomainException(string s, ValidationException validationException)
    : Exception(s, validationException);