namespace MVCalc //TODO путь в пространстве имен должен соответствовать физ.пути файла начиная от папки с проектом. Т.е. в данном случае MVCalc.Models - и кстати в папке будет много моделей - поэтому Models
{
    ///<summary>
    ///Содержит информацию о состоянии модели.
    ///</summary> 
    public class Data //TODO Модели должны иметь суффикс Model
    {
        public double Result; //TODO Почему тут не property а field?
        public bool ResultOK; //TODO Почему тут не property а field?
    }
}
