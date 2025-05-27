using IH.EventSystem.SoundEvent;
using IH.EventSystem.SystemEvent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YH.EventSystem;
using YH.Players;

public class TutorialGenerateComplete : MonoBehaviour
{
    [SerializeField] private GameEventChannelSO _systemChannel;
    [SerializeField] private GameEventChannelSO _soundChannel;
    [SerializeField] private SoundSO _soundDataSo;
    [SerializeField] private List<LevelRoom> _levelRoomList;
    [SerializeField] private Player _player;
    private LevelRoom _currentRoom;

    private void Awake()
    {
        foreach (var room in _levelRoomList)
        {
            room.OpenDoors.ForEach(x => x.SetOpen(true));
            room.DoorInvalidateCheck();
            room.gameObject.SetActive(false);
        }

        _currentRoom = _levelRoomList[0];
        _currentRoom.gameObject.SetActive(true);

        Transform playerTransform = (_currentRoom as StartLevelRoom).playerSpawnPoint;
        _player = Instantiate(_player, playerTransform.position, Quaternion.identity);
    }

    private void Start()
    {
        var evt = SystemEvents.FirstFadeSetting;
        _systemChannel.RaiseEvent(evt);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        var fadeOutEvent = SystemEvents.FadeScreenEvent;
        fadeOutEvent.isFadeIn = true;
        fadeOutEvent.isCircle = true;
        fadeOutEvent.fadeDuration = 0.5f;

        _systemChannel.AddListener<FadeComplete>(MusicPlay);

        yield return new WaitForSeconds(0.5f);
        _systemChannel.RaiseEvent(fadeOutEvent);
    }

    private void MusicPlay(FadeComplete evt)
    {
        _systemChannel.RemoveListener<FadeComplete>(MusicPlay);

        var soundEvt = SoundEvents.PlayBGMEvent;
        soundEvt.clipData = _soundDataSo;
        _soundChannel.RaiseEvent(soundEvt);
    }
}
