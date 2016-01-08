using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class postVHSPro : MonoBehaviour {

	//main props
	float time_ = 0.0f;
	Material mat = null;	 	//1st pass
	Material mat2 = null;	//2nd pass
	Material mat3 = null;	//3rd pass
	Material mat4 = null;	//4th pass
	Material mat_clear = null;	//clear
	Material mat_tape = null;	//for tape noise
	
	RenderTexture texPass12 = null;  		//texture inbetween 1st and 2nd pass
	RenderTexture texPass23 = null;  		//texture inbetween 2nd and 3rd pass
	RenderTexture texLast = null; 		//latest frame / previous frame
	RenderTexture texFeedback = null; 	//feedback buffer
	RenderTexture texFeedback2 = null; 	//feedback buffer
	RenderTexture texClear = null;  		//texture to clear other textures
	RenderTexture texTape = null;  		//tape noise texture


	//groups/sections folding save
	public bool g_showCRT = true;
	public bool g_showNoise = true;
	public bool g_showJitter = true;
	public bool g_showSignal = true;
	public bool g_showFeedback = true;
	public bool g_showExtra = false;
	public bool g_showBypass = false;


	//CRT
	public int crtMode = 0; 
	public int crtLinesMode = 0;
	public float screenLinesNum = 240f;
	public float bleedAmount = 1f; //default 1.-2.
	public bool bleedDebugOn = false;

	public AnimationCurve bleedCurveY = AnimationCurve.Linear(0,1,1,0);
	public AnimationCurve bleedCurveI = AnimationCurve.Linear(0,0.5f,1,0);
	public AnimationCurve bleedCurveQ = AnimationCurve.Linear(0,0.5f,1,0);

	public int bleedLength = 21; 
	public bool bleedCurveEditModeOn = false;
	public bool bleedCurveIQSyncOn = true;

	//curves
	int max_curve_length = 50;
	Texture2D texCurves = null; //curves tex
	Vector4 curvesOffest = new Vector4(0, 0, 0, 0);  //since color couldn't be negative and curves could be
	float[,] curvesData = new float[50,3];

	public bool fisheyeOn = true;
	public float fisheyeBend = 2.0f; 
	public float fisheyeSize = 1.2f; 
	
	public bool vignetteOn = false;
	public float vignetteAmount = 1.0f; 
	public float vignetteSpeed = 1.0f; 


	//NOISE
	public int noiseLinesMode = 1;
	public float noiseLinesNum = 240f; //noise quantation for Y
	public float noiseQuantizeX = 0.0f; 

	public bool filmgrainOn = false;
	public float filmGrainAmount = 0.016f; 
	// public float filmGrainPower = 1.0f; //not using atm

	public bool signalNoiseOn = true; 
	public float signalNoiseAmount = 0.52f; 
	public float signalNoisePower = 0.83f; 


	public bool tapeNoiseOn = true;
	public float tapeNoiseTH = 0.63f; 
	public float tapeNoiseAmount = 1.0f; 
	public float tapeNoiseSpeed = 1.0f; 
	public bool lineNoiseOn = true;
	public float lineNoiseAmount = 1.0f; 
	public float lineNoiseSpeed = 5.0f; 


	//JITTER
	public bool scanLinesOn = false;
	public float scanLineWidth = 10.0f;
	
	public bool linesFloatOn = false; 
	public bool stretchOn = true;

	public bool twitchHOn = false; 
	public float twitchHFreq = 1.0f; //default .5-1.
	public bool twitchVOn = false; 
	public float twitchVFreq = 1.0f; //default .5-1.

	public bool jitterHOn = true; 
	public float jitterHAmount = 0.5f; //default .5-1.
	public bool jitterVOn = false; 
	public float jitterVAmount = 1.0f; //default 1.
	public float jitterVSpeed = 1.0f; //default 1.
	

	//SIGNAL TWEAK
	public bool signalTweakOn = false; 
	public float signalAdjustY = 0f; //Luma
	public float signalAdjustI = 0f; //Chrominance
	public float signalAdjustQ = 0f; //Chrominance

	public float signalShiftY = 1f; //Luma
	public float signalShiftI = 1f; //Chrominance
	public float signalShiftQ = 1f; //Chrominance


	public float gammaCorection = 1f; 

	//FEEDBACK
	public bool feedbackOn = false; 
	public int feedbackMode = 0; 
	public float feedbackThresh = 0.1f; 
	public float feedbackAmount = 2.0f; 	
	public float feedbackFade = 0.82f; 
	public bool feedbackDebugOn = false; 
	// public float feedbackAmp = 2.0f; 


	//TOOLS (ADDITIONAL SECTION)
	public bool independentTimeOn = false; 
	// public bool bleedDebugCurve = false; //later 


	//BYPASS
	public MovieTexture movieTex;
	public Sprite spriteTex;

	// public bool rebuildTextures = true;
	
	void Start(){

		//1st pass		
		mat = new Material(Shader.Find("Hidden/postVHSPro_First"));
		mat.hideFlags = HideFlags.DontSave;

		//2nd pass
		mat2 = new Material(Shader.Find("Hidden/postVHSPro_Second"));
		mat2.hideFlags = HideFlags.DontSave;

		//for feedback
		//3rd pass		
		mat3 = new Material(Shader.Find("Hidden/postVHSPro_Third"));
		mat3.hideFlags = HideFlags.DontSave;

		//4th pass	
		mat4 = new Material(Shader.Find("Hidden/postVHSPro_Forth"));
		mat4.hideFlags = HideFlags.DontSave;

		//clear mat
		mat_clear = new Material(Shader.Find("Hidden/postVHSPro_Clear"));
		mat_clear.hideFlags = HideFlags.DontSave;

		//tape noise
		mat_tape = new Material(Shader.Find("Hidden/postVHSPro_Tape"));
		mat_tape.hideFlags = HideFlags.DontSave;

		//texture for caching curves				
		if(crtMode==3) buildCurves();

		if(movieTex!=null){
	      movieTex.loop = true;
	      movieTex.Play();			
		}
	}

	void Awake(){		
		if(crtMode==3) buildCurves(); 
	}


	// Update is called once per frame
	void Update () {

        // if(Input.GetKeyDown(KeyCode.M)){
	       //  	if(Time.timeScale == 1.0f) Time.timeScale = 0.0f; else Time.timeScale = 1.0f;
	       //  	Debug.Log("xxx");  
        //     // if(movieTex.isPlaying) movieTex.Pause();
        //     // else movieTex.Play();
        // }
	
	}

	void CreateTextures(RenderTexture src){
		
		DestroyImmediate(texClear);
      texClear = new RenderTexture(src.width, src.height, src.depth);
      texClear.filterMode = FilterMode.Point; 
      texClear.Create();			      

		DestroyImmediate(texPass12);
      texPass12 = new RenderTexture(src.width, src.height, src.depth);
      texPass12.filterMode = FilterMode.Point; 
      texPass12.Create();			

      DestroyImmediate(texPass23);
      texPass23 = new RenderTexture(src.width, src.height, src.depth);
      texPass23.filterMode = FilterMode.Point; 
      texPass23.Create();

		DestroyImmediate(texFeedback); //clearTex(texFeedback);
   	texFeedback = new RenderTexture(src.width, src.height, 0); 
      texFeedback.hideFlags = HideFlags.HideAndDontSave;
      texFeedback.filterMode = FilterMode.Point; 
      texFeedback.Create();

		DestroyImmediate(texFeedback2); //clearTex(texFeedback2);
   	texFeedback2 = new RenderTexture(src.width, src.height, 0); 
      texFeedback2.hideFlags = HideFlags.HideAndDontSave;
      texFeedback2.filterMode = FilterMode.Point; 
      texFeedback2.Create();

		DestroyImmediate(texLast); //clearTex(texLast);
   	texLast = new RenderTexture(src.width, src.height, 0); 
      texLast.hideFlags = HideFlags.HideAndDontSave;
      texLast.filterMode = FilterMode.Point; 
      texLast.Create();	

      //clear textures //TODO without scr texture
		Graphics.Blit (texClear, texFeedback, mat_clear);
		Graphics.Blit (texClear, texFeedback2, mat_clear);
		Graphics.Blit (texClear, texLast, mat_clear);

		// Debug.Log("rebuildTextures");

	}
	
	void OnRenderImage (RenderTexture src, RenderTexture dest) {		

		//Create texture inbetween	and feedback texture	
		if(texPass12==null || (src.width!=texPass12.width || src.height!=texPass12.height)){			
			CreateTextures(src);				
		}

		//noise tex
		if(screenLinesNum<=0) screenLinesNum = src.height;
		if(tapeNoiseOn || filmgrainOn || lineNoiseOn)
		if(texTape==null || (texTape.height!=Mathf.Min( noiseLinesNum, screenLinesNum))){
		
			int texHeight = (int)Mathf.Min( noiseLinesNum, screenLinesNum);
			int texWidth = (int)( 
			 	 (float)texHeight * (float)src.width/(float)src.height );

			DestroyImmediate(texTape); //clearTex(texLast);
	   	texTape = new RenderTexture(texWidth, texHeight, 0); 
	      texTape.hideFlags = HideFlags.HideAndDontSave;
	      texTape.filterMode = FilterMode.Point; 
	      texTape.Create();	
	      
			Graphics.Blit (texClear, texTape, mat_tape); //clear texture
			// Debug.Log("xx");

		}


		if(independentTimeOn){ time_ = Time.unscaledTime; }
		else{ 					  time_ = Time.time; }


		//1ST PASS
		mat.SetFloat("time_", time_);	

		//[Noise]
		mat.SetFloat("screenLinesNum", screenLinesNum);	
		mat.SetFloat("noiseLinesNum", noiseLinesNum);
		mat.SetFloat("noiseQuantizeX", noiseQuantizeX);

		FeatureToggle(filmgrainOn, "VHS_FILMGRAIN_ON");//works for both

		FeatureToggle(tapeNoiseOn, "VHS_TAPENOISE_ON");//works for both

		FeatureToggle(lineNoiseOn, "VHS_LINENOISE_ON");//works for both

		
		//[Jitter & Twitch]
		FeatureToggle(jitterHOn, "VHS_JITTER_H_ON");
		mat.SetFloat("jitterHAmount", jitterHAmount);

		FeatureToggle(jitterVOn, "VHS_JITTER_V_ON");
		mat.SetFloat("jitterVAmount", jitterVAmount);
		mat.SetFloat("jitterVSpeed", jitterVSpeed);

		FeatureToggle(linesFloatOn, "VHS_LINESFLOAT_ON");		

		FeatureToggle(twitchHOn, "VHS_TWITCH_H_ON");
		mat.SetFloat("twitchHFreq", twitchHFreq);
		FeatureToggle(twitchVOn, "VHS_TWITCH_V_ON");
		mat.SetFloat("twitchVFreq", twitchVFreq);

		FeatureToggle(scanLinesOn, "VHS_SCANLINES_ON");
		mat.SetFloat("scanLineWidth", scanLineWidth);
		
		FeatureToggle(signalNoiseOn, "VHS_YIQNOISE_ON");
		mat.SetFloat("signalNoisePower", signalNoisePower);
		mat.SetFloat("signalNoiseAmount", signalNoiseAmount);


		FeatureToggle(stretchOn, "VHS_STRETCH_ON");


		/// 2ND PASS
		mat2.SetFloat("time_", time_);	

		//[CRT]
		mat2.SetFloat("screenLinesNum", screenLinesNum);

		Shader.DisableKeyword("VHS_OLD_THREE_PHASE");
		Shader.DisableKeyword("VHS_THREE_PHASE");
		Shader.DisableKeyword("VHS_TWO_PHASE");			

			  if(crtMode==0){ Shader.EnableKeyword("VHS_OLD_THREE_PHASE"); }
		else if(crtMode==1){ Shader.EnableKeyword("VHS_THREE_PHASE"); }
		else if(crtMode==2){ Shader.EnableKeyword("VHS_TWO_PHASE"); }
		else if(crtMode==3){ if(bleedCurveEditModeOn) buildCurves(); }
		
		//TODO only if update mode 
		mat2.SetTexture("_CurvesTex", texCurves);
		mat2.SetVector("curvesOffest", curvesOffest); 
		mat2.SetInt("bleedLength", bleedLength); 		
		FeatureToggle((crtMode==3), "VHS_CUSTOM_BLEED_ON");
		FeatureToggle(bleedDebugOn, "VHS_DEBUG_BLEEDING_ON");

		mat2.SetFloat("bleedAmount", bleedAmount);

		FeatureToggle(fisheyeOn, 	"VHS_FISHEYE_ON");
		mat2.SetFloat("fisheyeBend", fisheyeBend);
		mat2.SetFloat("fisheyeSize", fisheyeSize);

		FeatureToggle(vignetteOn, 	"VHS_VIGNETTE_ON");
		mat2.SetFloat("vignetteAmount", vignetteAmount);
		mat2.SetFloat("vignetteSpeed", vignetteSpeed);


		//[Signal Tweak]
		FeatureToggle(signalTweakOn, "VHS_SIGNAL_TWEAK_ON");

		mat2.SetFloat("signalAdjustY", signalAdjustY);
		mat2.SetFloat("signalAdjustI", signalAdjustI);
		mat2.SetFloat("signalAdjustQ", signalAdjustQ);

		mat2.SetFloat("signalShiftY", signalShiftY);
		mat2.SetFloat("signalShiftI", signalShiftI);
		mat2.SetFloat("signalShiftQ", signalShiftQ);

		mat2.SetFloat("gammaCorection", gammaCorection);
		
		
		//render


		// noises
		if(tapeNoiseOn || filmgrainOn || lineNoiseOn){

			mat_tape.SetFloat("time_", time_);	


			// FeatureToggle(filmgrainOn, "VHS_FILMGRAIN_ON"); //works 4 both
			mat_tape.SetFloat("filmGrainAmount", filmGrainAmount);
			// mat_tape.SetFloat("filmGrainPower", filmGrainPower);//not using atm

			// FeatureToggle(tapeNoiseOn, "VHS_TAPENOISE_ON"); //works 4 both
			mat_tape.SetFloat("tapeNoiseTH", tapeNoiseTH);
			mat_tape.SetFloat("tapeNoiseAmount", tapeNoiseAmount);
			mat_tape.SetFloat("tapeNoiseSpeed", tapeNoiseSpeed);

			// FeatureToggle(lineNoiseOn, "VHS_LINENOISE_ON"); //works 4 both
			mat_tape.SetFloat("lineNoiseAmount", lineNoiseAmount);
			mat_tape.SetFloat("lineNoiseSpeed", lineNoiseSpeed);

			Graphics.Blit(texTape, texTape, mat_tape);
			
			
			mat.SetTexture("_TapeTex", 		texTape);
			mat.SetFloat("tapeNoiseAmount", tapeNoiseAmount);
			// Debug.Log("xxx");

		}


		//if you are using movie texture or sprite 
		//the first pass will be aplied to it
		if(movieTex!=null) 			Graphics.Blit ( (Texture)movieTex, 			  texPass12, mat);
		else if(spriteTex!=null) 	Graphics.Blit ( (Texture)spriteTex.texture, texPass12, mat);
		else 								Graphics.Blit (src, texPass12, mat);

		if(!feedbackOn){
			Graphics.Blit (texPass12, dest, mat2);					
		}else{

			Graphics.Blit (texPass12, texPass23, mat2);

			//recalc feedback buffer
			mat3.SetTexture("_LastTex", 		texLast);
			mat3.SetTexture("_FeedbackTex", 	texFeedback);
			mat3.SetFloat("feedbackThresh", 	feedbackThresh);
			mat3.SetFloat("feedbackAmount", 	feedbackAmount);
			mat3.SetFloat("feedbackFade", 	feedbackFade);
			Graphics.Blit (texPass23, texFeedback2, mat3); 			
			
			Graphics.Blit (texFeedback2, texFeedback); //damn you windows - another pass :< 			

			//mix last frame and feedback buffer
			mat4.SetFloat("feedbackAmp", 	1.0f);
			// mat4.SetFloat("feedbackAmp", 	feedbackAmp);
			mat4.SetTexture("_FeedbackTex", 	texFeedback);			
			Graphics.Blit (texPass23, texLast, mat4);

			if(!feedbackDebugOn)
				Graphics.Blit (texLast, dest);
			else
				Graphics.Blit (texFeedback, dest);
			
		}

		// Graphics.Blit (src, dest, mat2); //test

	}


	//turn on/off features
	//is it good to switch keywords all the time? or only on change?
	void FeatureToggle(bool propVal, string featureName){

		if(propVal) 	Shader.EnableKeyword(featureName);
		else  			Shader.DisableKeyword(featureName);

	}

	//sample the curve
	void buildCurves(){ //AnimationCurve curve, int Length

		if(texCurves==null) texCurves  = new Texture2D(max_curve_length, 1, TextureFormat.RGBA32, false);

		//curves negative offsets
		curvesOffest[0] = 0.0f;
		curvesOffest[1] = 0.0f;
		curvesOffest[2] = 0.0f;
	
		//sample curves
		float t = 0.0f;
		for(int i=0; i<bleedLength; i++){

			t =  ((float)i)/((float)bleedLength);
			curvesData[i,0] = bleedCurveY.Evaluate( t );
			curvesData[i,1] = bleedCurveI.Evaluate( t );
			curvesData[i,2] = bleedCurveQ.Evaluate( t );
			if(bleedCurveIQSyncOn) curvesData[i,2] = curvesData[i,1]; //IQ sunc			

			if(curvesOffest[0]>curvesData[i,0]) curvesOffest[0] = curvesData[i,0];			
			if(curvesOffest[1]>curvesData[i,1]) curvesOffest[1] = curvesData[i,1];			
			if(curvesOffest[2]>curvesData[i,2]) curvesOffest[2] = curvesData[i,2];			
		};

		//offset is negative -> lets make it possitive
		curvesOffest[0] = Mathf.Abs(curvesOffest[0]); 		
		curvesOffest[1] = Mathf.Abs(curvesOffest[1]); 		
		curvesOffest[2] = Mathf.Abs(curvesOffest[2]);		
		
		for(int i=0; i<bleedLength; i++){

			curvesData[i,0] += curvesOffest[0]; 		
			curvesData[i,1] += curvesOffest[1]; 		
			curvesData[i,2] += curvesOffest[2]; 				

			//so the thing is  - this works super weird
			//instead of passing actual values it passes some wird stuff 
			//especially if u passing few different values			

			//also -2 is super weird)
			texCurves.SetPixel(-2+bleedLength-i, 0, new Color(curvesData[i,0],curvesData[i,1],curvesData[i,2]));				
			// texCurves.SetPixel(bleedLength-i, 0, new Color(curvesData[i,0],curvesData[i,1],curvesData[i,2]));				
			
		};

		texCurves.Apply();			

	}



}
