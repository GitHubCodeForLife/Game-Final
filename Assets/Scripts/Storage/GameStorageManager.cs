using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStorageManager {
    public static GameInfo gameInfo
    {
        // Default retrieval call
        get
        {
            if (_gameInfo == null)
            {
                StorageHandler storageHandler = new StorageHandler();
                _gameInfo = (GameInfo)storageHandler.LoadData("GameInfo");
                if (_gameInfo == null)
                {
                    _gameInfo = new GameInfo();
                }
            }
            return _gameInfo;
        }
        // Default defining call
        set
        {
            _gameInfo = value;
        }
    }
    private static GameInfo _gameInfo;
    public static void SaveGameInfo()
    {
        StorageHandler storageHandler = new StorageHandler();
        storageHandler.SaveData(gameInfo, "GameInfo");
    }
    public static ShopInfo shopInfo
    {
        // Default retrieval call
        get
        {
            if (_shopInfo == null)
            {
                StorageHandler storageHandler = new StorageHandler();
                _shopInfo = (ShopInfo)storageHandler.LoadData("ShopInfo");
                if (_shopInfo == null)
                {
                    _shopInfo = new ShopInfo();
                }
            }
            return _shopInfo;
        }
        // Default defining call
        set
        {
            _shopInfo = value;
        }
    }
    private static ShopInfo _shopInfo;
    public static void SaveShopInfo()
    {
        StorageHandler storageHandler = new StorageHandler();
        storageHandler.SaveData(shopInfo, "ShopInfo");
    }
}
