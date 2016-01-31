using UnityEngine;
using System.Collections.Generic;

public interface GodPower {

    bool canUsePowerOnMap();
    bool canUsePowerOnShrine();

    void usePowerOnMap(Vector3 point, God godUsingPower);
    void usePowerOnShrine(Shrine s, God godUsingPower);

    float getEnergyCost();
}
