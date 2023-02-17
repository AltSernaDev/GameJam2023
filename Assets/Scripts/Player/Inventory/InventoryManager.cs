using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private int slotSlectedt = 0;

    public Slot[] invetoryItems;
    public UnityAction<int> onAddItem;
    public UnityAction<int> onSlotEmpty;
    public UnityAction<int> onSlotSelectedChanged;
    public static UnityAction onItemCounted;

    public AchievementLoader achievementLoader;
    public int collectedSeedsA , collectedSeedsB , collectedSeedsC , collectedSeedsD , collectedSeedsAB , collectedSeedsBC , collectedSeedsAC , collectedSeedsDA , collectedSeedsDB, collectedSeedsDC;
    public int SlotSlectedt
    {
        get { return slotSlectedt; }
        set
        {
            if (value < 0)
                value = invetoryItems.Length - 1;

            slotSlectedt = value % invetoryItems.Length;
            return;
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            SlotSlectedt++;
            onSlotSelectedChanged?.Invoke(slotSlectedt);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            SlotSlectedt--;
            onSlotSelectedChanged?.Invoke(slotSlectedt);
            
        }

        #region Achievement
        if (collectedSeedsA == 1)
        {
            achievementLoader.gameAchievements[0].UnlockedAchievement();
        }
        if (collectedSeedsB == 1)
        {
            achievementLoader.gameAchievements[1].UnlockedAchievement();
        }
        if (collectedSeedsC == 1)
        {
            achievementLoader.gameAchievements[2].UnlockedAchievement();
        }
        if (collectedSeedsD == 1)
        {
            achievementLoader.gameAchievements[3].UnlockedAchievement();
        }
        if (collectedSeedsAB == 1)
        {
            achievementLoader.gameAchievements[4].UnlockedAchievement();
        }
        if (collectedSeedsBC == 1)
        {
            achievementLoader.gameAchievements[5].UnlockedAchievement();
        }
        if (collectedSeedsAC == 1)
        {
            achievementLoader.gameAchievements[6].UnlockedAchievement();
        }
        if (collectedSeedsDA == 1)
        {
            achievementLoader.gameAchievements[7].UnlockedAchievement();
        }
        if (collectedSeedsDB == 1)
        {
            achievementLoader.gameAchievements[8].UnlockedAchievement();
        }
        if (collectedSeedsDC == 1)
        {
            achievementLoader.gameAchievements[9].UnlockedAchievement();
        } 
        #endregion
    }
    public bool AddToInventory(Seeds item)
    {
        switch (item.Type)
        {
            case TypeSeed.a:
                collectedSeedsA++;
                break;
            case TypeSeed.b:
                collectedSeedsB++;
                break;
            case TypeSeed.c:
                collectedSeedsC++;
                break;
            case TypeSeed.d:
                collectedSeedsD++;
                break;
            case TypeSeed.ab:
                collectedSeedsAB++;
                break;
            case TypeSeed.bc:
                collectedSeedsBC++;
                break;
            case TypeSeed.ac:
                collectedSeedsAC++;
                break;
            case TypeSeed.da:
                collectedSeedsDA++;
                break;
            case TypeSeed.db:
                collectedSeedsDB++;
                break;
            case TypeSeed.dc:
                collectedSeedsDC++;
                break;
        }


        bool canAdd = false;
        for (int i = 0; i < invetoryItems.Length; i++)
        {
            if (invetoryItems[i].itemsCount > 0 && item.Type == invetoryItems[i].items[0].Type)
            {
                if (invetoryItems[i].CanEnqueue())
                {
                    invetoryItems[i].AddItem(item);
                    canAdd = true;
                    return canAdd;
                }
            }
            else if (invetoryItems[i].itemsCount <= 0)
            {
                invetoryItems[i].AddItem(item);
                onAddItem?.Invoke(i);
                canAdd = true;
                return canAdd;
            }          
        }
        return canAdd;
    }

    public Seeds RemoveItem()
    {
        if (invetoryItems[SlotSlectedt].canRemove())
        {
            var temp= invetoryItems[SlotSlectedt].RemoveItem();
            if(invetoryItems[SlotSlectedt].items.Count <= 0) onSlotEmpty?.Invoke(SlotSlectedt);
            return temp;
        }
        else
        {
            return null;
        }       
        
    }

    public int ChangeNumber(int pos)
    {
        return invetoryItems[pos].itemsCount;

    }
}
