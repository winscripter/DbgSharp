namespace DbgSharp;

public record Variable(string Name, Type Type, bool IsReadOnly, dynamic Value);
