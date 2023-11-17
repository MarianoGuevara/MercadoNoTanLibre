using Entidades;

public delegate string DelegadoMostrar();

public delegate bool DelegadoIgualdad(object? o);

public delegate bool DelegadoVerificarString(string str, int entero); 

public delegate void DelegadoInformarParseoFallido(string str);

public delegate void DelegadoFecha(DateTime fecha);

public delegate void DelegadoSinParam();