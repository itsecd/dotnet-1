
using System.Collections.Generic;

interface IFunctionsDAO
{

    public void addFunc(int id);
    public void removeFunc(int id);

    public List<IFunctions> loadFile();
    public void unloadFile();


}