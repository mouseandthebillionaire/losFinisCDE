#pragma once

#ifdef RNBO_DESCRIPTION_AS_STRING

namespace RNBO {
	const std::string patcher_description(
			R"RNBOLIT({
  "parameters": [
    {
      "type": "ParameterTypeNumber",
      "index": 0,
      "name": "ratio_0",
      "paramId": "ratio_0",
      "minimum": 1,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumbe)RNBOLIT"
R"RNBOLIT(r",
      "index": 1,
      "name": "filter_0",
      "paramId": "filter_0",
      "minimum": 20,
      "maximum": 20000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 12000,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 2,
      "name": "index_0",
   )RNBOLIT"
R"RNBOLIT(   "paramId": "index_0",
      "minimum": 1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 3,
      "name": "drive",
      "paramId": "drive",
      "minimum": 0,
      "maximum": 10)RNBOLIT"
R"RNBOLIT(0,
      "exponent": 1,
      "steps": 0,
      "initialValue": 25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "Drive",
      "order": 3,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 4,
      "name": "resonance",
      "paramId": "resonance",
      "minimum": 0.1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      )RNBOLIT"
R"RNBOLIT("initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 5,
      "name": "balance",
      "paramId": "balance",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues":)RNBOLIT"
R"RNBOLIT( [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 6,
      "name": "midfreq",
      "paramId": "midfreq",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "MidFreq",
      "unit": "%",
)RNBOLIT"
R"RNBOLIT(      "order": 5,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 7,
      "name": "bass",
      "paramId": "bass",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Bass",
      "unit": "%",
      "order": 4,
      "debug": false,
      "visible": )RNBOLIT"
R"RNBOLIT(true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 8,
      "name": "ratio_1",
      "paramId": "ratio_1",
      "minimum": 1,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUnd)RNBOLIT"
R"RNBOLIT(efined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 9,
      "name": "index_1",
      "paramId": "index_1",
      "minimum": 1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
  )RNBOLIT"
R"RNBOLIT(    "index": 10,
      "name": "treble",
      "paramId": "treble",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Treble",
      "unit": "%",
      "order": 7,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 11,
      "name": "mid",
      "param)RNBOLIT"
R"RNBOLIT(Id": "mid",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Mid",
      "unit": "%",
      "order": 6,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 12,
      "name": "bpm",
      "paramId": "bpm",
      "minimum": 20,
      "maximum": 3000,
   )RNBOLIT"
R"RNBOLIT(   "exponent": 1,
      "steps": 0,
      "initialValue": 60,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 13,
      "name": "noteChance",
      "paramId": "noteChance",
      "minimum": 0,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialV)RNBOLIT"
R"RNBOLIT(alue": 50,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 14,
      "name": "arpStyle",
      "paramId": "arpStyle",
      "minimum": 1,
      "maximum": 3,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
)RNBOLIT"
R"RNBOLIT(      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 15,
      "name": "noteBredth",
      "paramId": "noteBredth",
      "minimum": 1,
      "maximum": 16,
      "exponent": 1,
      "steps": 0,
      "initialValue": 4,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "ord)RNBOLIT"
R"RNBOLIT(er": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 16,
      "name": "shimmerSpeed",
      "paramId": "shimmerSpeed",
      "minimum": 50,
      "maximum": 800,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible")RNBOLIT"
R"RNBOLIT(: true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 17,
      "name": "shimmerBredth",
      "paramId": "shimmerBredth",
      "minimum": 1,
      "maximum": 8,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType)RNBOLIT"
R"RNBOLIT(": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 18,
      "name": "reverb/inbandwidth",
      "paramId": "reverb/inbandwidth",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
  )RNBOLIT"
R"RNBOLIT(    "type": "ParameterTypeNumber",
      "index": 19,
      "name": "reverb/drywet",
      "paramId": "reverb/drywet",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "inde)RNBOLIT"
R"RNBOLIT(x": 20,
      "name": "reverb/decay2",
      "paramId": "reverb/decay2",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 21,
      "name": "reverb/predelay",
     )RNBOLIT"
R"RNBOLIT( "paramId": "reverb/predelay",
      "minimum": 0,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 10,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 22,
      "name": "reverb/indiffusion1",
      "paramId": "reverb/indiffusion1",
  )RNBOLIT"
R"RNBOLIT(    "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.75,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 23,
      "name": "reverb/decay1",
      "paramId": "reverb/decay1",
      "minimum": 0,
      "maximum": 1,
      ")RNBOLIT"
R"RNBOLIT(exponent": 1,
      "steps": 0,
      "initialValue": 0.7,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 24,
      "name": "reverb/indiffusion2",
      "paramId": "reverb/indiffusion2",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
  )RNBOLIT"
R"RNBOLIT(    "initialValue": 0.625,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 25,
      "name": "reverb/damping",
      "paramId": "reverb/damping",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": f)RNBOLIT"
R"RNBOLIT(alse,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 26,
      "name": "reverb/decay",
      "paramId": "reverb/decay",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName)RNBOLIT"
R"RNBOLIT(": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 27,
      "name": "attack",
      "paramId": "env.adsr/attack",
      "minimum": 0,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 30,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      )RNBOLIT"
R"RNBOLIT("debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 28,
      "name": "decay",
      "paramId": "env.adsr/decay",
      "minimum": 1,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 200,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "sign)RNBOLIT"
R"RNBOLIT(alIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 29,
      "name": "sustain",
      "paramId": "env.adsr/sustain",
      "minimum": 0,
      "maximum": 1,
      "exponent": 0.8,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefine)RNBOLIT"
R"RNBOLIT(d"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 30,
      "name": "release",
      "paramId": "env.adsr/release",
      "minimum": 1,
      "maximum": 90000,
      "exponent": 5,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeN)RNBOLIT"
R"RNBOLIT(umber",
      "index": 31,
      "name": "left",
      "paramId": "del_0/left",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 32,
      "name": "fb",
      )RNBOLIT"
R"RNBOLIT("paramId": "del_0/fb",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 33,
      "name": "right",
      "paramId": "del_0/right",
      "minimum": 10,
      "maxi)RNBOLIT"
R"RNBOLIT(mum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 34,
      "name": "attack",
      "paramId": "env.adsr[1]/attack",
      "minimum": 0,
      "maximum": 5000,
      "exponent": 3,
      "step)RNBOLIT"
R"RNBOLIT(s": 0,
      "initialValue": 30,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 35,
      "name": "decay",
      "paramId": "env.adsr[1]/decay",
      "minimum": 1,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 200,
      "isEnum")RNBOLIT"
R"RNBOLIT(: false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 36,
      "name": "sustain",
      "paramId": "env.adsr[1]/sustain",
      "minimum": 0,
      "maximum": 1,
      "exponent": 0.8,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "disp)RNBOLIT"
R"RNBOLIT(layName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 37,
      "name": "release",
      "paramId": "env.adsr[1]/release",
      "minimum": 1,
      "maximum": 90000,
      "exponent": 5,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "ord)RNBOLIT"
R"RNBOLIT(er": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 38,
      "name": "left",
      "paramId": "del_1/left",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
)RNBOLIT"
R"RNBOLIT(      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 39,
      "name": "fb",
      "paramId": "del_1/fb",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
)RNBOLIT"
R"RNBOLIT(    },
    {
      "type": "ParameterTypeNumber",
      "index": 40,
      "name": "right",
      "paramId": "del_1/right",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
 )RNBOLIT"
R"RNBOLIT(     "index": 41,
      "name": "rate",
      "paramId": "ampLFO_1/rate",
      "minimum": 0,
      "maximum": 10,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 42,
      "name": "pitchShift",
      "p)RNBOLIT"
R"RNBOLIT(aramId": "ampLFO_1/pitchShift",
      "minimum": 0.5,
      "maximum": 2,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 43,
      "name": "depth",
      "paramId": "ampLFO_1/depth",
      "minimum": 0,
 )RNBOLIT"
R"RNBOLIT(     "maximum": 5,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    }
  ],
  "numParameters": 44,
  "numSignalInParameters": 0,
  "numSignalOutParameters": 0,
  "numInputChannels": 0,
  "numOutputChannels": 2,
  "numMidiInputPorts": 1,
  "numMidiOutputPorts": 0,
  "e)RNBOLIT"
R"RNBOLIT(xternalDataRefs": [],
  "patcherSerial": 0,
  "inports": [],
  "outports": [],
  "inlets": [
    {
      "type": "midi"
    }
  ],
  "outlets": [
    {
      "type": "signal",
      "index": 1,
      "tag": "out1",
      "meta": ""
    },
    {
      "type": "signal",
      "index": 2,
      "tag": "out2",
      "meta": ""
    }
  ],
  "presetid": "rnbo",
  "meta": {
    "architecture": "x64",
    "filename": "LTHC_synth.maxpat",
    "rnboobjname": "LTHC_Synth",
    "maxversion": "8.5.6",
    "r)RNBOLIT"
R"RNBOLIT(nboversion": "1.2.1",
    "name": "synth"
  }
})RNBOLIT"
		);

	const std::string patcher_presets(
			R"RNBOLIT([
  {
    "name": "mainSynth",
    "preset": {
      "__sps": {
        "Drive~": {},
        "Post-EQ~": {
          "__sps": {
            "Bass~": {},
            "Mid~": {},
            "Treble~": {}
          }
        },
        "ampLFO_1": {
          "depth": {
            "value": 1
          },
          "pitchShift": {
            "value": 1
          },
          "rate": {
            "value": 1
          }
        },
        "del_0": {
          "fb": {
            "value": 0.6
    )RNBOLIT"
R"RNBOLIT(      },
          "left": {
            "value": 300
          },
          "right": {
            "value": 900
          }
        },
        "del_1": {
          "fb": {
            "value": 0.7270000000000002
          },
          "left": {
            "value": 300
          },
          "right": {
            "value": 600
          }
        },
        "env.adsr": {
          "attack": {
            "value": 45.96638385492399
          },
          "decay": {
            "value": 200
     )RNBOLIT"
R"RNBOLIT(     },
          "release": {
            "value": 300
          },
          "sustain": {
            "value": 0.5
          }
        },
        "env.adsr[1]": {
          "attack": {
            "value": 30
          },
          "decay": {
            "value": 200
          },
          "release": {
            "value": 300
          },
          "sustain": {
            "value": 0.5
          }
        },
        "filter.lp[2]": {},
        "osc.fm": {},
        "osc.fm[1]": {}
      },
  )RNBOLIT"
R"RNBOLIT(    "arpStyle": {
        "value": 1
      },
      "balance": {
        "value": 0.4700000000000001
      },
      "bass": {
        "value": 3
      },
      "bpm": {
        "value": 255
      },
      "drive": {
        "value": 0
      },
      "filter_0": {
        "value": 1024
      },
      "index_0": {
        "value": 1
      },
      "index_1": {
        "value": 10
      },
      "mid": {
        "value": 43
      },
      "midfreq": {
        "value": 7
      },
      "noteBredth":)RNBOLIT"
R"RNBOLIT( {
        "value": 4
      },
      "noteChance": {
        "value": 50
      },
      "ratio_0": {
        "value": 1
      },
      "ratio_1": {
        "value": 1
      },
      "resonance": {
        "value": 1
      },
      "reverb/damping": {
        "value": 0.5
      },
      "reverb/decay": {
        "value": 0.5
      },
      "reverb/decay1": {
        "value": 0.7
      },
      "reverb/decay2": {
        "value": 0.5
      },
      "reverb/drywet": {
        "value": 0.43307086614)RNBOLIT"
R"RNBOLIT(173196
      },
      "reverb/inbandwidth": {
        "value": 0.5
      },
      "reverb/indiffusion1": {
        "value": 0.75
      },
      "reverb/indiffusion2": {
        "value": 0.625
      },
      "reverb/predelay": {
        "value": 10
      },
      "shimmerBredth": {
        "value": 5
      },
      "shimmerSpeed": {
        "value": 109
      },
      "treble": {
        "value": 0
      }
    }
  }
])RNBOLIT"
		);
}

#else

#include <json/json.hpp>

namespace RNBO {
	const nlohmann::json patcher_description = nlohmann::json::parse(
			std::string(
				R"RNBOLIT({
  "parameters": [
    {
      "type": "ParameterTypeNumber",
      "index": 0,
      "name": "ratio_0",
      "paramId": "ratio_0",
      "minimum": 1,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumbe)RNBOLIT"
R"RNBOLIT(r",
      "index": 1,
      "name": "filter_0",
      "paramId": "filter_0",
      "minimum": 20,
      "maximum": 20000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 12000,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 2,
      "name": "index_0",
   )RNBOLIT"
R"RNBOLIT(   "paramId": "index_0",
      "minimum": 1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 3,
      "name": "drive",
      "paramId": "drive",
      "minimum": 0,
      "maximum": 10)RNBOLIT"
R"RNBOLIT(0,
      "exponent": 1,
      "steps": 0,
      "initialValue": 25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "Drive",
      "order": 3,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 4,
      "name": "resonance",
      "paramId": "resonance",
      "minimum": 0.1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      )RNBOLIT"
R"RNBOLIT("initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 5,
      "name": "balance",
      "paramId": "balance",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues":)RNBOLIT"
R"RNBOLIT( [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 6,
      "name": "midfreq",
      "paramId": "midfreq",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "MidFreq",
      "unit": "%",
)RNBOLIT"
R"RNBOLIT(      "order": 5,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 7,
      "name": "bass",
      "paramId": "bass",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Bass",
      "unit": "%",
      "order": 4,
      "debug": false,
      "visible": )RNBOLIT"
R"RNBOLIT(true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 8,
      "name": "ratio_1",
      "paramId": "ratio_1",
      "minimum": 1,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUnd)RNBOLIT"
R"RNBOLIT(efined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 9,
      "name": "index_1",
      "paramId": "index_1",
      "minimum": 1,
      "maximum": 20,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
  )RNBOLIT"
R"RNBOLIT(    "index": 10,
      "name": "treble",
      "paramId": "treble",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Treble",
      "unit": "%",
      "order": 7,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 11,
      "name": "mid",
      "param)RNBOLIT"
R"RNBOLIT(Id": "mid",
      "minimum": -100,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "Mid",
      "unit": "%",
      "order": 6,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 12,
      "name": "bpm",
      "paramId": "bpm",
      "minimum": 20,
      "maximum": 3000,
   )RNBOLIT"
R"RNBOLIT(   "exponent": 1,
      "steps": 0,
      "initialValue": 60,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 13,
      "name": "noteChance",
      "paramId": "noteChance",
      "minimum": 0,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialV)RNBOLIT"
R"RNBOLIT(alue": 50,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 14,
      "name": "arpStyle",
      "paramId": "arpStyle",
      "minimum": 1,
      "maximum": 3,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
)RNBOLIT"
R"RNBOLIT(      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 15,
      "name": "noteBredth",
      "paramId": "noteBredth",
      "minimum": 1,
      "maximum": 16,
      "exponent": 1,
      "steps": 0,
      "initialValue": 4,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "ord)RNBOLIT"
R"RNBOLIT(er": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 16,
      "name": "shimmerSpeed",
      "paramId": "shimmerSpeed",
      "minimum": 50,
      "maximum": 800,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible")RNBOLIT"
R"RNBOLIT(: true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 17,
      "name": "shimmerBredth",
      "paramId": "shimmerBredth",
      "minimum": 1,
      "maximum": 8,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType)RNBOLIT"
R"RNBOLIT(": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 18,
      "name": "reverb/inbandwidth",
      "paramId": "reverb/inbandwidth",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
  )RNBOLIT"
R"RNBOLIT(    "type": "ParameterTypeNumber",
      "index": 19,
      "name": "reverb/drywet",
      "paramId": "reverb/drywet",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "inde)RNBOLIT"
R"RNBOLIT(x": 20,
      "name": "reverb/decay2",
      "paramId": "reverb/decay2",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 21,
      "name": "reverb/predelay",
     )RNBOLIT"
R"RNBOLIT( "paramId": "reverb/predelay",
      "minimum": 0,
      "maximum": 100,
      "exponent": 1,
      "steps": 0,
      "initialValue": 10,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 22,
      "name": "reverb/indiffusion1",
      "paramId": "reverb/indiffusion1",
  )RNBOLIT"
R"RNBOLIT(    "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.75,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 23,
      "name": "reverb/decay1",
      "paramId": "reverb/decay1",
      "minimum": 0,
      "maximum": 1,
      ")RNBOLIT"
R"RNBOLIT(exponent": 1,
      "steps": 0,
      "initialValue": 0.7,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 24,
      "name": "reverb/indiffusion2",
      "paramId": "reverb/indiffusion2",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
  )RNBOLIT"
R"RNBOLIT(    "initialValue": 0.625,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 25,
      "name": "reverb/damping",
      "paramId": "reverb/damping",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": f)RNBOLIT"
R"RNBOLIT(alse,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 26,
      "name": "reverb/decay",
      "paramId": "reverb/decay",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName)RNBOLIT"
R"RNBOLIT(": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 27,
      "name": "attack",
      "paramId": "env.adsr/attack",
      "minimum": 0,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 30,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      )RNBOLIT"
R"RNBOLIT("debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 28,
      "name": "decay",
      "paramId": "env.adsr/decay",
      "minimum": 1,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 200,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "sign)RNBOLIT"
R"RNBOLIT(alIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 29,
      "name": "sustain",
      "paramId": "env.adsr/sustain",
      "minimum": 0,
      "maximum": 1,
      "exponent": 0.8,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefine)RNBOLIT"
R"RNBOLIT(d"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 30,
      "name": "release",
      "paramId": "env.adsr/release",
      "minimum": 1,
      "maximum": 90000,
      "exponent": 5,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeN)RNBOLIT"
R"RNBOLIT(umber",
      "index": 31,
      "name": "left",
      "paramId": "del_0/left",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 32,
      "name": "fb",
      )RNBOLIT"
R"RNBOLIT("paramId": "del_0/fb",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 33,
      "name": "right",
      "paramId": "del_0/right",
      "minimum": 10,
      "maxi)RNBOLIT"
R"RNBOLIT(mum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 34,
      "name": "attack",
      "paramId": "env.adsr[1]/attack",
      "minimum": 0,
      "maximum": 5000,
      "exponent": 3,
      "step)RNBOLIT"
R"RNBOLIT(s": 0,
      "initialValue": 30,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 35,
      "name": "decay",
      "paramId": "env.adsr[1]/decay",
      "minimum": 1,
      "maximum": 5000,
      "exponent": 3,
      "steps": 0,
      "initialValue": 200,
      "isEnum")RNBOLIT"
R"RNBOLIT(: false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 36,
      "name": "sustain",
      "paramId": "env.adsr[1]/sustain",
      "minimum": 0,
      "maximum": 1,
      "exponent": 0.8,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "disp)RNBOLIT"
R"RNBOLIT(layName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 37,
      "name": "release",
      "paramId": "env.adsr[1]/release",
      "minimum": 1,
      "maximum": 90000,
      "exponent": 5,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "ord)RNBOLIT"
R"RNBOLIT(er": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 38,
      "name": "left",
      "paramId": "del_1/left",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 300,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
)RNBOLIT"
R"RNBOLIT(      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 39,
      "name": "fb",
      "paramId": "del_1/fb",
      "minimum": 0,
      "maximum": 1,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.25,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
)RNBOLIT"
R"RNBOLIT(    },
    {
      "type": "ParameterTypeNumber",
      "index": 40,
      "name": "right",
      "paramId": "del_1/right",
      "minimum": 10,
      "maximum": 10000,
      "exponent": 1,
      "steps": 0,
      "initialValue": 400,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
 )RNBOLIT"
R"RNBOLIT(     "index": 41,
      "name": "rate",
      "paramId": "ampLFO_1/rate",
      "minimum": 0,
      "maximum": 10,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0.5,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 42,
      "name": "pitchShift",
      "p)RNBOLIT"
R"RNBOLIT(aramId": "ampLFO_1/pitchShift",
      "minimum": 0.5,
      "maximum": 2,
      "exponent": 1,
      "steps": 0,
      "initialValue": 1,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    },
    {
      "type": "ParameterTypeNumber",
      "index": 43,
      "name": "depth",
      "paramId": "ampLFO_1/depth",
      "minimum": 0,
 )RNBOLIT"
R"RNBOLIT(     "maximum": 5,
      "exponent": 1,
      "steps": 0,
      "initialValue": 0,
      "isEnum": false,
      "enumValues": [],
      "displayName": "",
      "unit": "",
      "order": 0,
      "debug": false,
      "visible": true,
      "signalIndex": null,
      "ioType": "IOTypeUndefined"
    }
  ],
  "numParameters": 44,
  "numSignalInParameters": 0,
  "numSignalOutParameters": 0,
  "numInputChannels": 0,
  "numOutputChannels": 2,
  "numMidiInputPorts": 1,
  "numMidiOutputPorts": 0,
  "e)RNBOLIT"
R"RNBOLIT(xternalDataRefs": [],
  "patcherSerial": 0,
  "inports": [],
  "outports": [],
  "inlets": [
    {
      "type": "midi"
    }
  ],
  "outlets": [
    {
      "type": "signal",
      "index": 1,
      "tag": "out1",
      "meta": ""
    },
    {
      "type": "signal",
      "index": 2,
      "tag": "out2",
      "meta": ""
    }
  ],
  "presetid": "rnbo",
  "meta": {
    "architecture": "x64",
    "filename": "LTHC_synth.maxpat",
    "rnboobjname": "LTHC_Synth",
    "maxversion": "8.5.6",
    "r)RNBOLIT"
R"RNBOLIT(nboversion": "1.2.1",
    "name": "synth"
  }
})RNBOLIT"
			)
		);

	const nlohmann::json patcher_presets = nlohmann::json::parse(
			std::string(
				R"RNBOLIT([
  {
    "name": "mainSynth",
    "preset": {
      "__sps": {
        "Drive~": {},
        "Post-EQ~": {
          "__sps": {
            "Bass~": {},
            "Mid~": {},
            "Treble~": {}
          }
        },
        "ampLFO_1": {
          "depth": {
            "value": 1
          },
          "pitchShift": {
            "value": 1
          },
          "rate": {
            "value": 1
          }
        },
        "del_0": {
          "fb": {
            "value": 0.6
    )RNBOLIT"
R"RNBOLIT(      },
          "left": {
            "value": 300
          },
          "right": {
            "value": 900
          }
        },
        "del_1": {
          "fb": {
            "value": 0.7270000000000002
          },
          "left": {
            "value": 300
          },
          "right": {
            "value": 600
          }
        },
        "env.adsr": {
          "attack": {
            "value": 45.96638385492399
          },
          "decay": {
            "value": 200
     )RNBOLIT"
R"RNBOLIT(     },
          "release": {
            "value": 300
          },
          "sustain": {
            "value": 0.5
          }
        },
        "env.adsr[1]": {
          "attack": {
            "value": 30
          },
          "decay": {
            "value": 200
          },
          "release": {
            "value": 300
          },
          "sustain": {
            "value": 0.5
          }
        },
        "filter.lp[2]": {},
        "osc.fm": {},
        "osc.fm[1]": {}
      },
  )RNBOLIT"
R"RNBOLIT(    "arpStyle": {
        "value": 1
      },
      "balance": {
        "value": 0.4700000000000001
      },
      "bass": {
        "value": 3
      },
      "bpm": {
        "value": 255
      },
      "drive": {
        "value": 0
      },
      "filter_0": {
        "value": 1024
      },
      "index_0": {
        "value": 1
      },
      "index_1": {
        "value": 10
      },
      "mid": {
        "value": 43
      },
      "midfreq": {
        "value": 7
      },
      "noteBredth":)RNBOLIT"
R"RNBOLIT( {
        "value": 4
      },
      "noteChance": {
        "value": 50
      },
      "ratio_0": {
        "value": 1
      },
      "ratio_1": {
        "value": 1
      },
      "resonance": {
        "value": 1
      },
      "reverb/damping": {
        "value": 0.5
      },
      "reverb/decay": {
        "value": 0.5
      },
      "reverb/decay1": {
        "value": 0.7
      },
      "reverb/decay2": {
        "value": 0.5
      },
      "reverb/drywet": {
        "value": 0.43307086614)RNBOLIT"
R"RNBOLIT(173196
      },
      "reverb/inbandwidth": {
        "value": 0.5
      },
      "reverb/indiffusion1": {
        "value": 0.75
      },
      "reverb/indiffusion2": {
        "value": 0.625
      },
      "reverb/predelay": {
        "value": 10
      },
      "shimmerBredth": {
        "value": 5
      },
      "shimmerSpeed": {
        "value": 109
      },
      "treble": {
        "value": 0
      }
    }
  }
])RNBOLIT"
			)
		);
}

#endif
