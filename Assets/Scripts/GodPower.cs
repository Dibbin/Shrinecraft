using UnityEngine;
using System.Collections.Generic;

public interface GodPower {

    bool canUsePowerOnMap();
    bool canUsePowerOnShrine();

    void usePowerOnMap();
    void usePowerOnShrine(Shrine shrine);

    float getEnergyCost();
}
