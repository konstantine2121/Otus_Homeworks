namespace Pattern_Prototype
{
    //IMyCloneable
    //ICloneable

    public interface IMyCloneable<T>
    {
        T CloneMe();//Чтобы не совпадало по сигнатуре с ICloneable
    }


}
