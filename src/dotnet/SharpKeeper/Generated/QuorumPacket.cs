// File generated by hadoop record compiler. Do not edit.
/**
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using Org.Apache.Jute;

namespace Org.Apache.Zookeeper.Server.Quorum
{
public class QuorumPacket : IRecord, IComparable 
{
  public QuorumPacket() {
  }
  public QuorumPacket(
  int type
,
  long zxid
,
  byte[] data
,
  System.Collections.Generic.List<Org.Apache.Zookeeper.Data.ZKId> authinfo
) {
Type=type;
Zxid=zxid;
Data=data;
Authinfo=authinfo;
  }
  public int Type { get; set; } 
  public long Zxid { get; set; } 
  public byte[] Data { get; set; } 
  public System.Collections.Generic.List<Org.Apache.Zookeeper.Data.ZKId> Authinfo { get; set; } 
  public void Serialize(IOutputArchive a_, String tag) {
    a_.StartRecord(this,tag);
    a_.WriteInt(Type,"type");
    a_.WriteLong(Zxid,"zxid");
    a_.WriteBuffer(Data,"data");
    {
      a_.StartVector(Authinfo,"authinfo");
      if (Authinfo!= null) {          int len1 = Authinfo.Count;
          for(int vidx1 = 0; vidx1<len1; vidx1++) {
            IRecord e1 = (IRecord) Authinfo[vidx1];
    a_.WriteRecord(e1,"e1");
          }
      }
      a_.EndVector(Authinfo,"authinfo");
    }
    a_.EndRecord(this,tag);
  }
  public void Deserialize(IInputArchive a_, String tag) {
    a_.StartRecord(tag);
    Type=a_.ReadInt("type");
    Zxid=a_.ReadLong("zxid");
    Data=a_.ReadBuffer("data");
    {
      IIndex vidx1 = a_.StartVector("authinfo");
      if (vidx1!= null) {          Authinfo=new System.Collections.Generic.List<Org.Apache.Zookeeper.Data.ZKId>();
          for (; !vidx1.Done(); vidx1.Incr()) {
    Org.Apache.Zookeeper.Data.ZKId e1;
    e1= new Org.Apache.Zookeeper.Data.ZKId();
    a_.ReadRecord(e1,"e1");
            Authinfo.Add(e1);
          }
      }
    a_.EndVector("authinfo");
    }
    a_.EndRecord(tag);
}
  public override String ToString() {
    try {
      System.IO.MemoryStream ms = new System.IO.MemoryStream();
      System.IO.BinaryWriter writer =
        new System.IO.BinaryWriter(ms);
      BinaryOutputArchive a_ = 
        new BinaryOutputArchive(writer);
      a_.StartRecord(this,"");
    a_.WriteInt(Type,"type");
    a_.WriteLong(Zxid,"zxid");
    a_.WriteBuffer(Data,"data");
    {
      a_.StartVector(Authinfo,"authinfo");
      if (Authinfo!= null) {          int len1 = Authinfo.Count;
          for(int vidx1 = 0; vidx1<len1; vidx1++) {
            IRecord e1 = (IRecord) Authinfo[vidx1];
    a_.WriteRecord(e1,"e1");
          }
      }
      a_.EndVector(Authinfo,"authinfo");
    }
      a_.EndRecord(this,"");
      ms.Position = 0;
      return System.Text.Encoding.UTF8.GetString(ms.ToArray());
    } catch (Exception ex) {
      Console.WriteLine(ex.StackTrace);
    }
    return "ERROR";
  }
  public void Write(System.IO.BinaryWriter writer) {
    BinaryOutputArchive archive = new BinaryOutputArchive(writer);
    Serialize(archive, "");
  }
  public void ReadFields(System.IO.BinaryReader reader) {
    BinaryInputArchive archive = new BinaryInputArchive(reader);
    Deserialize(archive, "");
  }
  public int CompareTo (object peer_) {
    throw new InvalidOperationException("comparing QuorumPacket is unimplemented");
  }
  public override bool Equals(object peer_) {
    if (!(peer_ is QuorumPacket)) {
      return false;
    }
    if (peer_ == this) {
      return true;
    }
    bool ret = false;
    QuorumPacket peer = (QuorumPacket)peer_;
    ret = (Type==peer.Type);
    if (!ret) return ret;
    ret = (Zxid==peer.Zxid);
    if (!ret) return ret;
    ret = Data.Equals(peer.Data);
    if (!ret) return ret;
    ret = Authinfo.Equals(peer.Authinfo);
    if (!ret) return ret;
     return ret;
  }
  public override int GetHashCode() {
    int result = 17;
    int ret;
    ret = (int)Type;
    result = 37*result + ret;
    ret = (int)Zxid;
    result = 37*result + ret;
    ret = Data.GetHashCode();
    result = 37*result + ret;
    ret = Authinfo.GetHashCode();
    result = 37*result + ret;
    return result;
  }
  public static string Signature() {
    return "LQuorumPacket(ilB[LId(ss)])";
  }
}
}