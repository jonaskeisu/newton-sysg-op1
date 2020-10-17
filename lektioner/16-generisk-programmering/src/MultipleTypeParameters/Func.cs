namespace MultipleTypeParameters
{
    interface Func<A, R> 
    {
        R Call(A arg);
    }
}