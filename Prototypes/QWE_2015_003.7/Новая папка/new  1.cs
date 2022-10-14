public class UClass
{
	public List<double> Ulist = new List<double>();
}
public Cluster CRecord(List<UClass> MyUCluster, Cluster C, double q, Cluster MySuperCluster)
{
	Cluster rez= new Cluster();
	rez=C;
	/*Перебераес кластеры*/
	int j = 0;
	foreach (Cluster MyCluster in rez.SCluster)
	{
		double zn = 0;
		/*перебираем предприяьтия*/
		for (int k = 0; k < MyUCluster[j].Ulist.Count(); k++)
		{
			zn = zn + Math.Pow(MyUCluster[j].Ulist[k], q);
		}
		int i1=0;
		/*перебираем в кластерах группы*/
		foreach (Group MyGroup in MyCluster.CGroupList)
		{
			int i2=0;
			/*перибираем в группах в кластерах параметры*/
			foreach (Param MyParam in MyGroup.GParamList)
			{
				double ch = 0;
				/*перебираем предприятия*/
				for (int k = 0; k < MyUCluster[j].Ulist.Count(); k++)
				{
					ch = 
ch + Math.Pow(MyUCluster[j].Ulist[k], q) * MySuperCluster.SCluster[k].CGroupList[i1].GParamList[i2].P;
				}
				MyCluster.CGroupList[i1].GParamList[i2].P = ch / zn;
				i2++;
			}
			i1++;
		}
		j++;
	}
	return rez;
}
        