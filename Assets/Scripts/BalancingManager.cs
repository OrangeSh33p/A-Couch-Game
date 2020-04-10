using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class BalancingManager : MonoBehaviour {
    [Header("OPTIONS")]
    public bool useHeads;
    public bool useButts;
    public bool useElbows;
    public bool useKnees;
    [Space]
    public bool lateralizeBodies;
    public bool lateralizeCushions;
    public bool lateralizeArmrests;
    public bool lateralizeBackrests;
    [Space]
    public PM playMode;

    [Header("STATE")]
    public List<BodyPartName> usedBodyParts;
    public List<BodyPartName> usedEasyBodyParts;
    public List<BodyPartName> usedHardBodyParts;
    public List<CouchPart> usedCouchParts;
    public List<CouchPart> usedEasyCouchParts;
    public List<CouchPart> usedHardCouchParts;

    [Header("REFERENCES")]
    public List<CouchPart> allCouchParts;
    public List<BodyPartName> allBodyParts;
    public List<CouchPart> allEasyCouchParts;
    public List<BodyPartName> allEasyBodyParts;

    private void Start () {
        usedBodyParts = BuildBodyParts ();
        usedCouchParts = BuildCouchParts ();

        usedEasyBodyParts = usedBodyParts.Intersect(allEasyBodyParts).ToList();
        usedHardBodyParts = usedBodyParts.Except(allEasyBodyParts).ToList();
        usedEasyCouchParts = usedCouchParts.Intersect(allEasyCouchParts).ToList();
        usedHardCouchParts = usedCouchParts.Except(allEasyCouchParts).ToList();
    }

    public List<BodyPartName> BuildBodyParts () {
        List<BodyPartName> bodyParts = allBodyParts;

        if (!useHeads) bodyParts.Remove (BodyPartName.head);
        if (!useButts) bodyParts.Remove (BodyPartName.butt);

        if (lateralizeBodies) {
            bodyParts.Remove (BodyPartName.hand);
            bodyParts.Remove (BodyPartName.foot);
            bodyParts.Remove (BodyPartName.elbow);
            bodyParts.Remove (BodyPartName.knee);

            if (!useElbows) {
                bodyParts.Remove (BodyPartName.leftElbow);
                bodyParts.Remove (BodyPartName.rightElbow);
            } 

            if (!useKnees) {
                bodyParts.Remove (BodyPartName.leftKnee);
                bodyParts.Remove (BodyPartName.rightKnee);
            } 
        } else {
            bodyParts.Remove (BodyPartName.leftHand);
            bodyParts.Remove (BodyPartName.rightHand);
            bodyParts.Remove (BodyPartName.leftFoot);
            bodyParts.Remove (BodyPartName.rightFoot);
            bodyParts.Remove (BodyPartName.leftElbow);
            bodyParts.Remove (BodyPartName.rightElbow);
            bodyParts.Remove (BodyPartName.leftKnee);
            bodyParts.Remove (BodyPartName.rightKnee);

            if (!useElbows) bodyParts.Remove (BodyPartName.elbow);
            if (!useKnees) bodyParts.Remove (BodyPartName.knee);
        }

        return bodyParts;
    }

    public List<CouchPart> BuildCouchParts () {
        List<CouchPart> couchParts = allCouchParts;

        if (lateralizeArmrests) {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.armrest);
        } else {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.leftArmrest);
            couchParts = RemoveCouchPart (couchParts, CouchPartName.rightArmrest);
        }

        if (lateralizeBackrests) {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.backrest);
        } else {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.leftBackrest);
            couchParts = RemoveCouchPart (couchParts, CouchPartName.rightBackrest);
        }

        if (lateralizeCushions) {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.cushion);
        } else {
            couchParts = RemoveCouchPart (couchParts, CouchPartName.leftCushion);
            couchParts = RemoveCouchPart (couchParts, CouchPartName.rightCushion);
        }

        return couchParts;
    }

    private List<CouchPart> RemoveCouchPart(List<CouchPart> usedCouchParts, CouchPartName partToRemove) {
        return usedCouchParts.Where(part => part.couchPartName != partToRemove).ToList();
    }
}

public enum PM {
    ORDERED_TURNS,
    RANDOM_TURNS,
    NO_TURNS
}