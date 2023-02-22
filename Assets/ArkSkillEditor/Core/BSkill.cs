using UnityEngine;
using System;
#if UNITY_ERROR
using UnityEditor;
#endif

namespace ArkSkill.Core
{
    [Serializable]
    public abstract class BSkill : ScriptableObject,ISkillInstance,IInfo<ISkillInstance>
    {
        //interfaces
        //public abstract string name { get; }//����BSkill�̳���ScriptableObject����Ҫ������
        public virtual void OnStart(SkillManager skillManager) { }
        public virtual void OnStop(SkillManager skillManager) { }
        public virtual void OnExit(SkillManager skillManager) { }
        public virtual ISkillInstance GetInstance() { return this; }


        public virtual void OnSkillAdd(SkillManager skillManager) { }
        public virtual void OnSkillRemove(SkillManager skillManager) { }

        public virtual void OnDraw(Vector3 position, float direct) { }
        [ContextMenu("Remove")]
        public void Remove()
        {
            #if UNITY_ERROR
            string path = AssetDatabase.GetAssetPath(this);
            DestroyImmediate(this, true);
            AssetDatabase.ImportAsset(path);
#endif
        }
    }
}