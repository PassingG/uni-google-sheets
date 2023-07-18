#if UNITY_2017_1_OR_NEWER || UNITY_BUILD
using GoogleSheet;
using GoogleSheet.Protocol.v2.Req;
using GoogleSheet.Protocol.v2.Res;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace UGS
{
    public class UnityPlayerWebRequest : MonoBehaviour, IHttpProtcol
    {
        public bool reqProcessing = false;

        public static UnityPlayerWebRequest Instance
        {
            get
            {
                if (instance == null)
                {
                    var data = new GameObject().AddComponent<UnityPlayerWebRequest>();
                    instance = data;
                    data.gameObject.name = "UnityPlayerWebRequest";
                }

                return instance;
            }
        }

        private static UnityPlayerWebRequest instance;


        public string baseURL
        {
            get { return UGSettingObjectWrapper.ScriptURL; }
        }

        void Awake()
        {
            //singleton
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        async UniTaskVoid Get<T>(string uri, Action<System.Exception> OnError, Action<T> callback) where T : Response
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                webRequest.timeout = 60;
                await webRequest.SendWebRequest();
                if (webRequest.error == null)
                {
                    var deserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);
                    if (!deserialize.hasError())
                    {
                        callback?.Invoke(deserialize);
                    }
                    else
                    {
                        OnError(new System.Exception("응답 없음 => " + webRequest.downloadHandler.text));
                    }
                }
                else
                {
                    reqProcessing = false;
                    OnError(new System.Exception(webRequest.error));
                }

                reqProcessing = false;
            }
        }


        async UniTaskVoid Post<T>(string json, Action<System.Exception> OnError, Action<T> callback) where T : Response
        {
            JObject jo = JObject.Parse(json);
            jo.Add("password", UGSettingObjectWrapper.ScriptPassword);
            json = jo.ToString();
            var request = new UnityWebRequest(baseURL, "POST");

            Debug.LogError(json);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.timeout = 60;
            await request.SendWebRequest();

            if (request.error == null)
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
                if (data.hasError())
                {
                    OnError(new UGSWebError(data.error.message));
                }
                else
                {
                    callback?.Invoke(data);
                }
            }
            else
            {
                OnError?.Invoke(new System.Exception(request.error));
            }

            reqProcessing = false;
        }

        public void GetDriveDirectory(GetDriveDirectoryReqModel mdl, Action<System.Exception> errResponse, Action<GetDriveFolderResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            var url = baseURL + HttpUtils.ToQueryString(mdl, UGSettingObjectWrapper.ScriptPassword);

            Get<GetDriveFolderResult>(url, errResponse, (x) =>
            {
                if (x.hasError())
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void ReadSpreadSheet(ReadSpreadSheetReqModel mdl, Action<System.Exception> errResponse, Action<ReadSpreadSheetResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            var url = baseURL + HttpUtils.ToQueryString(mdl, UGSettingObjectWrapper.ScriptPassword);
            Get<ReadSpreadSheetResult>(url, errResponse, (x) =>
            {
                if (x.hasError())
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void WriteObject(WriteObjectReqModel mdl, Action<System.Exception> errResponse, Action<WriteObjectResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            Post<WriteObjectResult>(Newtonsoft.Json.JsonConvert.SerializeObject(mdl), errResponse, (x) =>
            {
                if (x.hasError())
                {
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                }
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void WriteObjects(WriteObjectsReqModel mdl, Action<System.Exception> errResponse, Action<WriteObjectResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            Post<WriteObjectResult>(Newtonsoft.Json.JsonConvert.SerializeObject(mdl), errResponse, (x) =>
            {
                if (x.hasError())
                {
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                }
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void CreateDefaultSheet(CreateDefaultReqModel mdl, Action<System.Exception> errResponse, Action<CreateDefaultSheetResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            var url = baseURL + HttpUtils.ToQueryString(mdl, UGSettingObjectWrapper.ScriptPassword);

            Get<CreateDefaultSheetResult>(url, errResponse, (x) =>
            {
                if (x.hasError())
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void CopyExample(CopyExampleReqModel mdl, Action<System.Exception> errResponse, Action<CreateExampleResult> callback)
        {
            if (reqProcessing)
            {
                Debug.Log("이미 요청중입니다..");
                return;
            }
            else
                reqProcessing = true;

            var url = baseURL + HttpUtils.ToQueryString(mdl, UGSettingObjectWrapper.ScriptPassword);

            Get<CreateExampleResult>(url, errResponse, (x) =>
            {
                if (x.hasError())
                    errResponse?.Invoke(new UGSWebError(x.error.message));
                else
                {
                    callback?.Invoke(x);
                }
            }).Forget();
        }

        public void CopyFolder(CopyFolderReqModel mdl, Action<System.Exception> errResponse, Action<CreateExampleResult> callback)
        {
            throw new NotImplementedException();
        }
    }
}


#endif