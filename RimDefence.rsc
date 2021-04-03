<?xml version="1.0" encoding="utf-8"?>
<savedscenario>
	<meta>
		<gameVersion>1.2.2900 rev837</gameVersion>
		<modIds>
			<li>brrainz.harmony</li>
			<li>me.samboycoding.betterloading</li>
			<li>ludeon.rimworld</li>
			<li>lingluo.preparecarefully</li>
			<li>ludeon.rimworld.royalty</li>
			<li>xhou.towerdefence</li>
		</modIds>
		<modNames>
			<li>Harmony</li>
			<li>BetterLoading</li>
			<li>Core</li>
			<li>EdB Prepare Carefully_zh</li>
			<li>Royalty</li>
			<li>Tower Defence</li>
		</modNames>
	</meta>
	<scenario>
		<name>RimDefence</name>
		<summary>RimDefence 1.0</summary>
		<description>Version: 1.0
Auther: xhou
Date: 2021-4-1
</description>
		<playerFaction>
			<def>PlayerFaction</def>
			<factionDef>PlayerColony</factionDef>
		</playerFaction>
		<parts>
			<li Class="ScenPart_ConfigPage_ConfigureStartingPawns">
				<def>ConfigPage_ConfigureStartingPawns</def>
				<pawnCount>4</pawnCount>
				<pawnChoiceCount>8</pawnChoiceCount>
			</li>
			<li Class="ScenPart_PlayerPawnsArriveMethod">
				<def>PlayerPawnsArriveMethod</def>
				<method>DropPods</method>
			</li>
			<li Class="ScenPart_GameStartDialog">
				<def>GameStartDialog</def>
				<text>Welcome to RimDefence 1.0

You need to protect energy core from waves of enemies.</text>
				<closeSound>GameStartSting</closeSound>
			</li>
			<li Class="ScenPart_DisableIncident">
				<def>DisableIncident</def>
				<incident>ShortCircuit</incident>
			</li>
			<li Class="ScenPart_DisableIncident">
				<def>DisableIncident</def>
				<incident>CropBlight</incident>
			</li>
			<li Class="ScenPart_DisableIncident">
				<def>DisableIncident</def>
				<incident>Infestation</incident>
			</li>
			<li Class="ScenPart_DisableIncident">
				<def>DisableIncident</def>
				<incident>Disease_Flu</incident>
			</li>
			<li Class="ScenPart_Rule_DisallowDesignator">
				<def>Rule_DisallowDesignator_ZoneAdd_Growing</def>
			</li>
			<li Class="ScenPart_StatFactor">
				<def>StatFactor</def>
				<stat>HungerRateMultiplier</stat>
			</li>
			<li Class="ScenPart_StatFactor">
				<def>StatFactor</def>
				<stat>EquipDelay</stat>
			</li>
			<li Class="ScenPart_StatFactor">
				<def>StatFactor</def>
				<stat>BedRestEffectiveness</stat>
				<factor>99.99</factor>
			</li>
		</parts>
	</scenario>
</savedscenario>