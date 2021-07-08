﻿import * as THREE from "three";

import { Attacks } from "./Attack";
import { terrainShader } from "./TerrainShader";
import { Player } from "./Player";
import { GameObject, attackableAlphaMapTexture } from "./Attackable";
import { NonPlayerCharacter as NPC } from "./NonPlayerCharacter";

// import { addPlayer, removePlayer, highlightPlayerOnMap, unhighlightPlayerOnMap } from "../stores/map/actions";
import { NpcData, PlayerData, Step } from "./Types";

export class World extends THREE.Object3D {

    private objects:
        {
            [id: number]: GameObject,
        };
    private attacks: Attacks;
    private ready: boolean;

    /*
     * Constructs a new World object.
     * It's automatically initializes and updates it's containing objects by using
     * the WorldUpdater which uses SignalRto talk with the server.
     * @constructor
     * @param {Store} store - the redux store which holds a map State with a player list
     * @param {number} serverId - the id of the server where the map is hosted
     * @param {number} mapId - the id of the map
     */
    constructor(serverId: number, mapId: number) {
        super();
        this.objects = {};
        this.attacks = new Attacks();
        this.attacks.position.z = 100;
        this.add(this.attacks);

        const planeMesh = new THREE.Mesh(
            new THREE.PlaneGeometry(256, 256, 1, 1),
            new THREE.ShaderMaterial(terrainShader));
        this.add(planeMesh);

        const textureLoader = new THREE.TextureLoader();
        textureLoader.load('terrain/' + serverId + '/' + mapId, (texture: THREE.Texture) => {
            texture.magFilter = THREE.NearestFilter;
            terrainShader.uniforms.tColor.value = texture;
        });
    }

    public update() : void {
        this.attacks.update();
        const objects = this.objects;
        for (let o in objects) {
            if (objects.hasOwnProperty(o)) {
                const object = objects[o];
                if (object instanceof Player) {
                    object.update();
                }
            }
        }
    }

    public async addOrUpdateNpc(npcData: NpcData) {
        const obj = this.getObjectById(npcData.id);
        if (obj === undefined || obj === null) {
            while (attackableAlphaMapTexture === undefined) {
                await new Promise(resolve => setTimeout(resolve, 50));
            }

            console.debug("Adding npc", npcData);
            this.addNpc(npcData);
        } else {
            console.debug("Updating npc", npcData);
            obj.respawn(npcData);
        }
    }

    public async addOrUpdatePlayer(playerData: PlayerData) {
        const obj = this.getObjectById(playerData.id);
        if (obj === undefined || obj === null) {
            while (attackableAlphaMapTexture === undefined) {
                await new Promise(resolve => setTimeout(resolve, 50));
            }

            console.debug("Adding player", playerData);
            this.addPlayer(playerData);
        } else {
            console.debug("Updating player", playerData, obj.data);
            obj.respawn(playerData);
        }
    }

    public killObject(killedObjectId: number, killerObjectId: number) : void {
        const killedObject = this.getObjectById(killedObjectId);
        killedObject?.gotKilled();
    }

    public objectMoved(id: number, newX: number, newY: number, moveType: any, walkDelay: number, steps: Step[]) : void {
        const obj = this.getObjectById(id);
        obj?.moveTo(newX, newY, moveType, walkDelay, steps);
    }

    public addSkillAnimation(playerId: number, targetId: number, skill: number) : void {
        const animating = this.getObjectById(playerId);
        const target = this.getObjectById(targetId);
        this.attacks.addAttack(animating, target);
        // todo add effect
    }

    public addAreaSkillAnimation(playerId: number, skill: number, x: number, y: number, rotation: number) : void {
        const animating = this.getObjectById(playerId);
        if (animating !== undefined && animating !== null) {
            animating.rotateTo(rotation);
            // todo add effect
        }
    }

    public addAnimation(animatingId: number, animation: number, targetId: number, direction: number) : void {
        const animating = this.getObjectById(animatingId);
        if (animating !== undefined && animating !== null) {
            animating.rotateTo(direction / 0x10);
        }

        if (targetId !== null) {
            const target = this.getObjectById(targetId);
            this.attacks.addAttack(animating, target);
            // todo add effect instead of attack
        }
    }

    public dispose() : void {
        delete this.objects;
    }

    public highlightOn(objectId: number) : void {
        const player = this.getObjectById(objectId) as Player;
        if (player != null) {
            player.data = { ... player.data, isHighlighted: true };
        }
    }

    public highlightOff(objectId: number) : void {
        const player = this.getObjectById(objectId) as Player;
        if (player != null) {
            player.data = { ... player.data, isHighlighted: false };
        }
    }

    /*
     * Is called when the size of the render target changed.
     * This will set the size of the highlighted edges - their width should be exactly 1 pixel
     */
    public onSizeChanged(newSize: number) {
        terrainShader.uniforms.tPixelSize.value = 256.0 / newSize;
    }

    /*
     * Adds a new non-player-character to the map with the specified data.
     */
    public addNpc(data: NpcData) {
        const npc = new NPC(data);
        this.addObjectMesh(npc);
        npc.respawn(data);
    }

    /*
     * Adds a new player to the map with the specified data.
     */
    public addPlayer(data: PlayerData) {
        const player = new Player(data);
        this.addObjectMesh(player);
        player.respawn(data);
    }

    /*
     * Removes the object with the specified id from the map.
     */
    public removeObject(objectId: number) {
        const mesh = this.objects[objectId];
        console.debug("Removing object", mesh.data);
        this.remove(mesh as THREE.Object3D);
        delete this.objects[objectId];
    }

    /*
     * Gets an object of the map by it's id.
     */
    public getObjectById(objectId: number): GameObject {
        return this.objects[objectId];
    }

    private addObjectMesh(mesh: GameObject) {
        this.add(mesh);
        this.objects[mesh.data.id] = mesh;
    }
};
