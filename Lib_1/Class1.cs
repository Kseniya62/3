using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_6
{
	public class Class2
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="matr">матрица</param>
		/// <param name="mas">массив</param>

		public static void Старт(int[,] matr, out int[] mas)
		{
			int sum = 0;
			mas = new int[matr.GetLength(1)];
			for (int j = 1; j < matr.GetLength(1); j+=2)
				{
				sum = 0;
				for (int i = 0; i < matr.GetLength(0); i ++)
				{
					sum += matr[i, j];
				}
				mas[j] = sum;
			}
		}
	}
}

