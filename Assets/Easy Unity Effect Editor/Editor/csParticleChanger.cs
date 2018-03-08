using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class csParticleChanger : MonoBehaviour {

    public void ObjectScaleChagne(float Value)
    {
        transform.localScale *= Value; // Change Object Scale Value.
    }

	public void ShurikenParticleScaleChange(float _Value)
	{
		//Define All of the Particle Object that included this Object
		ParticleSystem[] ParticleSystems = GetComponentsInChildren<ParticleSystem>();

		//Find Object One by One
		foreach(ParticleSystem _ParticleSystem in ParticleSystems)
        {
			//Able to Approach not use SerializedObject
			_ParticleSystem.startSpeed *= _Value;
			_ParticleSystem.startSize *= _Value;
			_ParticleSystem.gravityModifier *= _Value;
			//Only SerializedObject can approach to the Selection Tap.
			//So Define SerializedObject.
			SerializedObject _SerializedObject = new SerializedObject(_ParticleSystem);
			//Change Values
			//if you want to change other value, refer "SerializedObject date of Shuriken Particle System.txt", write code.
			_SerializedObject.FindProperty("CollisionModule.particleRadius").floatValue *= _Value;
			_SerializedObject.FindProperty("ShapeModule.radius").floatValue *= _Value;
			_SerializedObject.FindProperty("ShapeModule.boxX").floatValue *= _Value;
			_SerializedObject.FindProperty("ShapeModule.boxY").floatValue *= _Value;
			_SerializedObject.FindProperty("ShapeModule.boxZ").floatValue *= _Value;
			_SerializedObject.FindProperty("VelocityModule.x.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("VelocityModule.y.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("VelocityModule.z.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("ClampVelocityModule.x.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("ClampVelocityModule.y.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("ClampVelocityModule.z.scalar").floatValue *= _Value;
			_SerializedObject.FindProperty("ClampVelocityModule.magnitude.scalar").floatValue *= _Value;
			//Apply Values
			_SerializedObject.ApplyModifiedProperties();
		}
	}

    public void ShurikenParticleColorChange(Color ShurikenColor)
    {
        //Define All of the Particle Object that included this Object
        ParticleSystem[] ParticleSystems = GetComponentsInChildren<ParticleSystem>();
        //Find Object One by One
        foreach (ParticleSystem _ParticleSystem in ParticleSystems)
        {
            //Change Color
            _ParticleSystem.startColor = ShurikenColor;
        }
    }

    public void LegacyEffectScaleChange(float Value)
    {
        //Define All of the Particle Object that included this Objects
        ParticleEmitter[] ParticleEmitters = GetComponentsInChildren<ParticleEmitter>();
        ParticleAnimator[] ParticleAnimators = GetComponentsInChildren<ParticleAnimator>();
        ParticleRenderer[] ParticleRenderers = GetComponentsInChildren<ParticleRenderer>();

        //Find Object One by One
        foreach (ParticleEmitter _ParticleEmitter in ParticleEmitters)
        {
            //Change Value
            _ParticleEmitter.minSize *= Value;
            _ParticleEmitter.maxSize *= Value;
            _ParticleEmitter.localVelocity *= Value;
            _ParticleEmitter.rndAngularVelocity *= Value;
            _ParticleEmitter.rndVelocity *= Value;
            //Ellipsoid and tangetnVelocity is not able to approach normally.
            //so use SerializedObject.
            SerializedObject _SerializedObject = new SerializedObject(_ParticleEmitter);
            _SerializedObject.FindProperty("m_Ellipsoid").vector3Value *= Value;
            _SerializedObject.FindProperty("tangentVelocity").vector3Value *= Value;
            _SerializedObject.ApplyModifiedProperties();
        }

        //Find Object One by One
        foreach (ParticleAnimator _ParticleAnimator in ParticleAnimators)
        {
            //Change Value
            _ParticleAnimator.sizeGrow *= Value;
            _ParticleAnimator.force *= Value;
            _ParticleAnimator.rndForce *= Value;
        }

        //Find Object One by One
        foreach (ParticleRenderer _ParticleRenderer in ParticleRenderers)
        {
            //Change Value
            _ParticleRenderer.maxParticleSize *= Value;
        }
    }
}
