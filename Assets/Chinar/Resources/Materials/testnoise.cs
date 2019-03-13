// ========================================================
// 描述：
// 作者：Chinar 
// 创建时间：2019-02-19 17:11:42
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testnoise : MonoBehaviour {

    public Material mmm;

    [SerializeField, Range(0, 1)]
    float _scanLineJitter = 0;

    public float scanLineJitter
    {
        get { return _scanLineJitter; }
        set { _scanLineJitter = value; }
    }

    [SerializeField, Range(0, 1)]
    float _verticalJump = 0;

    public float verticalJump
    {
        get { return _verticalJump; }
        set { _verticalJump = value; }
    }

    [SerializeField, Range(0, 1)]
    float _horizontalShake = 0;

    public float horizontalShake
    {
        get { return _horizontalShake; }
        set { _horizontalShake = value; }
    }

    [SerializeField, Range(0, 1)]
    float _colorDrift = 0;

    public float colorDrift
    {
        get { return _colorDrift; }
        set { _colorDrift = value; }
    }
    float _verticalJumpTime;

    private void Awake()
    {
        DOTween.To(() => _scanLineJitter, x => _scanLineJitter = x, 1f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        DOTween.To(() => _colorDrift, x => _colorDrift = x, 0.1f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    public void Update()
    {
        _verticalJumpTime += Time.deltaTime * _verticalJump * 11.3f;

        var sl_thresh = Mathf.Clamp01(1.0f - _scanLineJitter * 1.2f);
        var sl_disp = 0.002f + Mathf.Pow(_scanLineJitter, 3) * 0.05f;
        mmm.SetVector("_ScanLineJitter", new Vector2(sl_disp, sl_thresh));

        var vj = new Vector2(_verticalJump, _verticalJumpTime);
        mmm.SetVector("_VerticalJump", vj);

        mmm.SetFloat("_HorizontalShake", _horizontalShake * 0.2f);

        var cd = new Vector2(_colorDrift * 0.04f, Time.time * 606.11f);
        mmm.SetVector("_ColorDrift", cd);
    }
}
