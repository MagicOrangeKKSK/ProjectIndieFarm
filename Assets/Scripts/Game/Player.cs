using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
	public partial class Player : ViewController
	{
		public Grid Grid;
		public Tilemap Tilemap;

		void Start()
		{
			// Code Here
		}

	   private void Update()
		{
			if (Input.GetKeyDown(KeyCode.J))
			{
				var cellPosition = Grid.WorldToCell(transform.position);
				Tilemap.SetTile(cellPosition, null); 
				
				//x,y ֵ
				 //��tilemap�����
				 //�õ������
			}

		}
	}
}
