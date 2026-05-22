using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beethebee.Scripts.Helpers
{
    public static class Helper
    {
        public const string FLOWER_COLLECTABLE_SCENE = "res://scenes/FlowerCollectable.tscn";
        public const string PATH_INFINITE_OBJECT_SCENE = "res://scenes/PathInfiniteObject.tscn";
        public const string ENEMY = "res://scenes/enemy.tscn";
        public const string MAIN = "res://main.tscn";
        public static IDictionary<int, string> FLOWER_ASSETS = new Dictionary<int, string> { //TODO: fazer o load pelo path funcionar (nao impeditivo)
            { 0, "res://assets/flower/yellow_flower_0.png" } ,
            { 1, "res://assets/flower/yellow_flower_1.png" } ,
            { 2, "res://assets/flower/yellow_flower_2.png" } ,
            { 3, "res://assets/flower/flower_red.png" } ,
        };
    }
}
